using UnityEngine;
using UnityEngine.SceneManagement;

public class Counter : MonoBehaviour
{
    private int pushCount = 0;

    public void OnButtonPressed()
    {
        pushCount++;

        Debug.Log("ƒ{ƒ^ƒ“‰ñ”" + pushCount);

        if(pushCount >= 8)
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
