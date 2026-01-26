using UnityEngine;

public class DayGameManager : MonoBehaviour
{
    public PlacementPattern pattern;
    public Transform[] stands;
    public SmallObjectController smallObjectPrefab;

    void Start()
    {
        ApplyPattern();
    }

    void ApplyPattern()
    {
        foreach (var entry in pattern.placements)
        {
            Transform mount =
                stands[entry.standIndex].GetChild(entry.mountPointIndex);

            var obj = Instantiate(
                smallObjectPrefab,
                mount.position,
                mount.rotation
            );

            obj.Apply(entry.data);
        }
    }
}
