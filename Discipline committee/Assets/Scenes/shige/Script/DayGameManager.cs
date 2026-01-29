using UnityEngine;
using System.Collections.Generic;

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

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
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
        }
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

}
