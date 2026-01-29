using UnityEngine;

public class KarmaManager : MonoBehaviour
{
    public static KarmaManager Instance;
    [Header("Karma Stting")]
    public int karma = 100;
    public int minKarma = 0;
    public int maxKarma = 200;

   void Awake()
    {
        Instance = this;
    }
    public void AddKarma(int value)
    {
        karma += value;
        karma = Mathf.Clamp(karma, minKarma, maxKarma);
        Debug.Log($"ƒJƒ‹ƒ}•Ï“®:{value} ->Œ»İ{karma}");
    }
}
