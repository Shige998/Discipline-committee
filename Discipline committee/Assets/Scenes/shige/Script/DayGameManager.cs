using UnityEngine;

public class DayGameManager : MonoBehaviour
{
    public DayData dayData;
    public Transform[] stands;
    public GameObject smallObjectPrefab;

    private int phaseIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartPhaseA();
    }

    // Update is called once per frame
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
        var pattern = phase.patterns[Random.Range(0,phase.patterns.Length)];

        foreach (var entry in pattern.placements)
        {
            Transform mount = stands[entry.standIndex].GetChild(entry.mountPointIndex);


            var obj = Instantiate(smallObjectPrefab,
                mount.position,
                mount.rotation
                );

            obj.GetComponent<SmallObjectController>()
                .Apply(entry.data);
        }
    }

    public void FinishPhase()
    {
        foreach (var obj in FindObjectsOfType<SmallObjectController>())
        {
            Destroy(obj.gameObject);
        }

        if (phaseIndex == 0)
            StartPhaseB();
        else
            Debug.Log("Day Finished");
    }
}
