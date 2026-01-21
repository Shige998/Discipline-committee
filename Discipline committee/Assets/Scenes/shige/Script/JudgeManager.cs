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
            Debug.LogWarning("Judge失敗：dataがnull");
            return false;
        }

        // 今回は「消していいか」だけを見る
        if (data.canRemove)
        {
            Debug.Log("判定：OK（正解）");
            return true;
        }
        else
        {
            Debug.Log("判定：NG（不正解）");
            return false;
        }
    }
}
