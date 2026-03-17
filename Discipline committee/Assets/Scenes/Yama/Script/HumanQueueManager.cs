using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanQueueManager : MonoBehaviour
{
    [Header("初期キャラデータ")]
    public List<HumanData> initialHumans;

    [Header("参照")]
    public HumanAssembler assembler;

    [Header("ポジション")]
    public Transform waitPoint;
    public Transform centerPoint;
    public Transform exitPoint;

    [Header("移動設定")]
    public float moveDuration = 0.5f;

    private Queue<HumanData> dataQueue;
    private Queue<GameObject> humanPool = new Queue<GameObject>();

    private GameObject waitingHuman;
    private GameObject centerHuman;
    private GameObject leavingHuman;

    private bool isMoving = false;
    public System.Action OnQueueFinished;

    bool IsAllFinished()
    {
        return dataQueue.Count == 0
            && waitingHuman == null
            && centerHuman == null
            && leavingHuman == null;
    }
    private void Awake()
    {
        dataQueue = new Queue<HumanData>(initialHumans);
    }

    private void Start()
    {
        SpawnInitial();
    }

    private void SpawnInitial()
    {
        waitingHuman = SpawnAt(waitPoint);
        centerHuman = SpawnAt(centerPoint);
    }

    public void AdvanceLine()
    {
        if (isMoving) return;
        if (centerHuman == null)
        {
            if(waitingHuman == null)
            {
                return;
            }
        }

        StartCoroutine(AdvanceRoutine());
    }

    private IEnumerator AdvanceRoutine()
    {
        if (centerHuman == null)
        {
            if (waitingHuman == null)
            {
                yield break;
            }
        }
        isMoving = true;

        // ① 中央を退場扱い
        leavingHuman = centerHuman;

        // ② 待機を中央へ
        centerHuman = waitingHuman;

        // ③ 新しい待機を生成
        waitingHuman = SpawnAt(waitPoint);

        // ④ 同時移動開始（この瞬間3人いる）
        StartCoroutine(MoveTo(centerHuman, centerPoint));
        StartCoroutine(MoveTo(leavingHuman, exitPoint));

        yield return new WaitForSeconds(moveDuration);

        // ⑤ 退場完了後Destroy
        Destroy(leavingHuman);
        leavingHuman = null;

        isMoving = false;

        if(IsAllFinished())
        {
            Debug.Log("全員終了！");
            OnQueueFinished();
            // 呼び出し：OnQueueFinished?.Invoke();
        }
    }

    private GameObject SpawnAt(Transform point)
    {
        GameObject human;

        if (humanPool.Count > 0)
        {
            human = humanPool.Dequeue();
            human.SetActive(true);
        }else
        {
            if (dataQueue.Count == 0)return null;

            HumanData data = dataQueue.Dequeue();
            dataQueue.Enqueue(data); // 循環させる場合は再度キューに戻す
            human = assembler.Assemble(data);
        }

        human.transform.position = point.position;
        human.transform.rotation = point.rotation;

        return human;
    }

    private IEnumerator MoveTo(GameObject obj, Transform target)
    {
        if (obj == null)
        {
            yield break;
        }
        Vector3 startPos = obj.transform.position;
        Quaternion startRot = obj.transform.rotation;

        float time = 0f;

        while (time < moveDuration)
        {
            float t = time / moveDuration;

            obj.transform.position = Vector3.Lerp(startPos, target.position, t);
            obj.transform.rotation = Quaternion.Slerp(startRot, target.rotation, t);

            time += Time.deltaTime;
            yield return null;
        }

        obj.transform.position = target.position;
        obj.transform.rotation = target.rotation;
    }
    public bool IsMoving()
    {
        return isMoving;
    }
}