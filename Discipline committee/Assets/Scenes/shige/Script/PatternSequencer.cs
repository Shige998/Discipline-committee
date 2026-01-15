using UnityEngine;

public class PatternSequencer : MonoBehaviour
{
    [Header("使用可能な配置パターン")]
    public PlacementPattern[] availablePatterns;

    [Header("台座一覧")]
    public ObjectStand[] stands;

    [Header("小物Prefab")]
    public SmallObjectController objectPrefab;

    [Header("実行回数（今回は1）")]
    public int repeatCount = 1;

    void Start()
    {
        for (int i = 0; i < repeatCount; i++)
        {
            ExecuteRandomPattern();
        }
    }

    void ExecuteRandomPattern()
    {
        var pattern = availablePatterns[Random.Range(0, availablePatterns.Length)];

        foreach (var entry in pattern.placements)
        {
            var stand = stands[entry.standIndex];
            var mount = stand.GetMountPoint(entry.mountPointIndex);

            if (mount == null) continue;

            var obj = Instantiate(objectPrefab);
            obj.Setup(entry.data);

            obj.transform.SetParent(mount);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
        }
    }
}
