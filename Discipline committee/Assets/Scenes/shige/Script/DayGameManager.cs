using UnityEngine;

public class DayGameManager : MonoBehaviour
{
    public DayData dayData;

    [Header("ë‰ç¿ÅiMountPointÇéqÇ…éùÇ¬Åj")]
    public Transform[] stands;

    [Header("è¨ï®Prefab")]
    public GameObject smallObjectPrefab;

    int phaseIndex = 0;

    void Start()
    {
        StartPhaseA();
    }

    void StartPhaseA()
    {
        ApplyRandomPattern(dayData.phaseA);
        phaseIndex = 0;
    }

    void StartPhaseB()
    {
        ApplyRandomPattern(dayData.phaseB);
        phaseIndex = 1;
    }

    void ApplyRandomPattern(PhasePattern phase)
    {
        var pattern = phase.patterns[Random.Range(0, phase.patterns.Length)];

        foreach (var entry in pattern.placements)
        {
            Transform mount =
                stands[entry.standIndex].GetChild(entry.mountPointIndex);

            Vector3 spawnPos =
                mount.position + Vector3.up * entry.data.heightOffset;

            var obj = Instantiate(
                smallObjectPrefab,
                spawnPos,
                Quaternion.Euler(entry.data.rotation)
            );

            obj.GetComponent<SmallObjectController>()
                .Apply(entry.data);

            obj.transform.localScale = entry.data.scale;
        }
    }

    public void FinishPhase()
    {
        foreach (var obj in FindObjectsByType<SmallObjectController>(FindObjectsSortMode.None))
        {
            Destroy(obj.gameObject);
        }


        if (phaseIndex == 0)
            StartPhaseB();
        else
            Debug.Log("Day Finished");
    }
}
