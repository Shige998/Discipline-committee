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
    [Header("Day Settings")]
    public int currentDay = 1;   // 必ず 1 にする
    public int maxDay = 5;


    [Header("Spawn Setting")]
    public Transform[] spawnPoints;
    public GameObject smallObjectPrefab;

    [Header("DataLists")]
    public List<SmallObjectData> correctObjects;
    public List<SmallObjectData> wrongObjects;

    [Header("Wrong Count Settings")]
    public int baseWrongCount = 1;
    public int maxWrongCount = 5;

    [Header("Count")]
    public int CorrectCount = 2;
    public int wrongCount = 1; // 初期は3個

    [Header("Bitton Count")]
    public int pressCount = 0;
    public int pressLimit = 8;

    [Header("Count Settings")]
    public CountMode countMode = CountMode.All;

    private List<GameObject> spawnedObjects = new List<GameObject>();


    void Start()
    {
        UpdateDaySettings();
        SpawnObjects();
    }

    // ================================
    // ボタンを押した時の処理
    // ================================
    public void OnSpawnButtonPressed()
    {
        EvaluateRemainingObjects();

        pressCount++;

        if (pressCount >= pressLimit)
        {
            pressCount = 0;
            NextDay();
            if (currentDay <= maxDay)
            {
                UpdateDaySettings(); // ← ここで日付に応じてWrong数を調整
            }
        }

        if (currentDay <= maxDay)
        {
            SpawnObjects();
        }
    }

    // ================================
    // 日付を進める
    // ================================


    void NextDay()
    {
        currentDay++;

        Debug.Log("currentDay = " + currentDay);

        if (currentDay > maxDay)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("EndScene");
            return;
        }

        Debug.Log("---- Day " + currentDay + " ----");
    }

    // ================================
    // 日によって Wrong を1ずつ増やす
    // ================================
    void UpdateDaySettings()
    {
        // 日付に応じて Wrong を 1 ずつ増やす
        wrongCount = Mathf.Min(baseWrongCount + (currentDay - 1), maxWrongCount);

        Debug.Log($"Day {currentDay}: WrongCount = {wrongCount}");
    }

    // ================================
    // オブジェクトスポーン
    // ================================
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

    // ================================
    // クリックされなかったオブジェクトの評価
    // ================================
    public void EvaluateRemainingObjects()
    {
        SmallObjectController[] remaining = FindObjectsOfType<SmallObjectController>();

        foreach (var obj in remaining)
        {
            if (obj == null || obj.data == null) continue;

            int baseValue = Mathf.Abs(obj.data.karmaValue);

            if (obj.data.resultType == ObjectResultType.Correct)
            {
                KarmaManager.Instance.AddKarma(-baseValue);
            }
            else
            {
                KarmaManager.Instance.AddKarma(+baseValue);
            }

            Destroy(obj.gameObject);
        }
    }

    // ================================
    // Utility
    // ================================
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
        for (int i = 0; i < list.Count; i++)
        {
            int r = Random.Range(i, list.Count);
            (list[i], list[r]) = (list[r], list[i]);
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
                case CountMode.All: count++; break;
                case CountMode.CorrectOnly:
                    if (obj.data.resultType == ObjectResultType.Correct) count++;
                    break;
                case CountMode.WrongOnly:
                    if (obj.data.resultType == ObjectResultType.Wrong) count++;
                    break;
            }
        }

        return count;
    }
}