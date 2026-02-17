using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class KarmaManager : MonoBehaviour
{
    public static KarmaManager Instance;
    [Header("Karma Stting")]
    public int karma = 100;
    public int minKarma = 0;
    public int maxKarma = 200;
    private TMP_Text karmaText;

   void Awake()
    {
        Instance = this;
        karmaText = GetComponent<TMP_Text>();
    }
    public void AddKarma(int value)
    {
        karma += value;
        karma = Mathf.Clamp(karma, minKarma, maxKarma);
        Debug.Log($"ÉJÉãÉ}ïœìÆ:{value} ->åªç›{karma}");
    }
}
