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
        if (data == null)
        {
            Debug.LogWarning("Judge¸”sFdata‚ªnull");
            return false;
        }

        return data.resultType == ObjectResultType.Correct;
       
    }
}
