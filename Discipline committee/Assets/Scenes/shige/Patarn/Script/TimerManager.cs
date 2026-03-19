using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public float timeRemaining = 60f;
    public TMP_Text timerText;

    private bool isTimeRunning = true;

    // 追加
    public DayGameManager gameManager;

    void Update()
    {
        if (!isTimeRunning) return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            isTimeRunning = false;

            // ❗ シーン遷移やめる
            if (gameManager != null)
            {
                gameManager.ShowResult(); // ←これを呼ぶ
            }
        }

        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        int seconds = Mathf.CeilToInt(timeRemaining);
        timerText.text = "Time:" + seconds;
    }

    // ⭐ タイマー再スタート用
    public void ResetTimer()
    {
        timeRemaining = 60f;
        isTimeRunning = true;
    }

    // ⭐ 停止用
    public void StopTimer()
    {
        isTimeRunning = false;
    }
}