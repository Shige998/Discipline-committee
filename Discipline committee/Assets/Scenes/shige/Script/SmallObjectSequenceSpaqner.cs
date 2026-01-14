using UnityEngine;

public class SmallObjectSequenceSpaqner : MonoBehaviour
{
    [Header("配置パターン(順番")]
    public SmallObjectData[] patterns;

    [Header("配置場所")]
    public ObjectStand[] stands;

    [Header("小物prefab")]
    public SmallObjectController objectPrefab;
    void Start()
    {
        SpawnSequence();
    }

    void SpawnSequence()
    {
        int count = Mathf.Min(patterns.Length, stands.Length);

        for (int  i = 0;  i < count;  i++)
        {
            var obj = Instantiate(objectPrefab);
            obj.Setup(patterns[i]);
            stands[i].Place(obj);
        }
    }
}
