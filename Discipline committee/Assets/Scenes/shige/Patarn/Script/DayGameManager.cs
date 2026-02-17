using UnityEngine;
using System.Collections.Generic;


public enum CountMode
{
    All,
    CorrectOnly,
    WrongOnly
}
public class DayGameManager : MonoBehaviour
{
    [Header("Spawn Setting")]
    public Transform[] spawnPoints;
    public GameObject smallObjectPrefab;

    [Header("DataLists")]
    public List<SmallObjectData> correctObjects;
    public List<SmallObjectData> wrongObjects;

    [Header("Count")]
    public int CorrectCount = 2;
    public int wrongCount = 3;

    [Header("Count Settings")]
    public CountMode countMode = CountMode.All;

    public void OnSpawnButtonPressed()
    {

        EvaluateRemainingObjects();

        SpawnObjects();
    }

    private List<GameObject> spawnedObjects = new List<GameObject>();

    void Start()
    {
        SpawnObjects();
    }

    public void SpawnObjects()
    {
        ClearObjects();


        List<SmallObjectData> spawnList = new List<SmallObjectData>();

        spawnList.AddRange(GetRandom(correctObjects, CorrectCount));
        spawnList.AddRange(GetRandom(wrongObjects, wrongCount));

        Shuffle(spawnList);

        for (int i = 0; i < spawnList.Count && i < spawnPoints.Length; i++)
        {
            GameObject obj = Instantiate(
               smallObjectPrefab,
                spawnPoints[i].position,
                spawnPoints[i].rotation
                );

            obj.GetComponent<SmallObjectController>()
                .Apply(spawnList[i]);

            spawnedObjects.Add(obj);
        }
    }

    void ClearObjects()
    {
     foreach (GameObject obj in spawnedObjects)
        {
            Destroy(obj);
        }
        spawnedObjects.Clear();
    }

    List<SmallObjectData> GetRandom(List<SmallObjectData> list, int count)
    {
        List<SmallObjectData> temp = new List<SmallObjectData>(list);
        Shuffle(temp);

        return temp.GetRange(0, Mathf.Min(count, temp.Count));
    }

    void Shuffle<T>(List<T> list)
    {
        for (int  i = 0;  i < list.Count;  i++)
        {
            int r = Random.Range(i, list.Count);
            (list[i], list[r]) = (list[r], list[i]);
        }
    }

    public void EvaluateRemainingObjects()
    {
        SmallObjectController[] remaining = FindObjectsOfType<SmallObjectController>();

        foreach (var obj in remaining)
        {
            if (obj == null || obj.data == null) continue;

            // オブジェクトの元の karmaValue を取得
            int baseValue = Mathf.Abs(obj.data.karmaValue);

            if (obj.data.resultType == ObjectResultType.Correct)
            {
                // 正解 → 逆処理でマイナス
                KarmaManager.Instance.AddKarma(-baseValue);

                Debug.Log($"未クリックの正解 → カルマ -{baseValue}");
            }
            else
            {
                // 不正解 → 逆処理でプラス
                KarmaManager.Instance.AddKarma(+baseValue);

                Debug.Log($"未クリックの不正解 → カルマ +{baseValue}");
            }

            // 最後に削除
            Destroy(obj.gameObject);
        }
    }

    public int CountRemainingObjects()
    {
        SmallObjectController[] all = FindObjectsOfType<SmallObjectController>();

        int count = 0;

        foreach (var obj in all)
        {
            if (obj == null || obj.data == null) continue;

            switch (countMode)
            {
                case CountMode.All:
                    count++;
                    break;

                case CountMode.CorrectOnly:
                    if (obj.data.resultType == ObjectResultType.Correct)
                        count++;
                    break;

                case CountMode.WrongOnly:
                    if (obj.data.resultType == ObjectResultType.Wrong)
                        count++;
                    break;
            }
        }

        return count;
    }

}
