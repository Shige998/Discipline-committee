using UnityEngine;

public class JudgeManager : MonoBehaviour
{
    public static JudgeManager Instance;

    [Header("Day Setting")]
    public int currentDay = 1;
    public PatternType correctPattern;

    void Awake()
    {
        Instance = this;
    }

    public bool Judge(SmallObjectData data)
    {
        bool patternOK = data.pattern == correctPattern;
        bool deleteOK = data.canRemove;

        return patternOK && deleteOK;
    }
}
