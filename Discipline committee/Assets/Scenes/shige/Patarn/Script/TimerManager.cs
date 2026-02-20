using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    public float timeRemaining = 60f;
    public TMP_Text timerText;

    bool isTimeRunning = true;


    void Update()
    {
        if (isTimeRunning)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                isTimeRunning = false;

                SceneManager.LoadScene("EndScene");
            }
            UpdateTimerUI();
        }
        
    }

    void UpdateTimerUI()
    {
        int seconds = Mathf.CeilToInt(timeRemaining);
        timerText.text = "Time:" +  seconds;
    }
}
