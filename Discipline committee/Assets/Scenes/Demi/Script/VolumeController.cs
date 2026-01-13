using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour
{
    [Header("AudioMixer")]
    [SerializeField] private AudioMixer audioMixer;

    [Header("UI - BGM")]
    [SerializeField] private Image bgmBarFill;
    [SerializeField] private Button bgmPlusButton;
    [SerializeField] private Button bgmMinusButton;

    [Header("UI - SE")]
    [SerializeField] private Image seBarFill;
    [SerializeField] private Button sePlusButton;
    [SerializeField] private Button seMinusButton;

    [Header("Volume Settings")]
    [SerializeField] private int maxLevel = 10;

    private int bgmLevel;
    private int seLevel;

    private const string BGM_KEY = "BGM_VOLUME";
    private const string SE_KEY = "SE_VOLUME";

    void Start()
    {
        // ‰Šúƒ[ƒh
        bgmLevel = PlayerPrefs.GetInt(BGM_KEY, maxLevel);
        seLevel = PlayerPrefs.GetInt(SE_KEY, maxLevel);

        ApplyBGM();
        ApplySE();

        // ƒ{ƒ^ƒ““o˜^
        bgmPlusButton.onClick.AddListener(() => ChangeBGM(1));
        bgmMinusButton.onClick.AddListener(() => ChangeBGM(-1));
        sePlusButton.onClick.AddListener(() => ChangeSE(1));
        seMinusButton.onClick.AddListener(() => ChangeSE(-1));
    }

    void ChangeBGM(int value)
    {
        bgmLevel = Mathf.Clamp(bgmLevel + value, 0, maxLevel);
        PlayerPrefs.SetInt(BGM_KEY, bgmLevel);
        ApplyBGM();
    }

    void ChangeSE(int value)
    {
        seLevel = Mathf.Clamp(seLevel + value, 0, maxLevel);
        PlayerPrefs.SetInt(SE_KEY, seLevel);
        ApplySE();
    }

    void ApplyBGM()
    {
        float volume = ConvertToDecibel(bgmLevel);
        audioMixer.SetFloat("BGMVolume", volume);
        bgmBarFill.fillAmount = (float)bgmLevel / maxLevel;
    }

    void ApplySE()
    {
        float volume = ConvertToDecibel(seLevel);
        audioMixer.SetFloat("SEVolume", volume);
        seBarFill.fillAmount = (float)seLevel / maxLevel;
    }

    float ConvertToDecibel(int level)
    {
        if (level == 0) return -80f;
        return Mathf.Lerp(-30f, 0f, (float)level / maxLevel);
    }
}
