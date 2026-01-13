using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [Header("Scene Transition")]
    [SerializeField] private string targetSceneName;

    // ボタン押下時に呼び出す
    public void OnClickSceneChange()
    {
        if (string.IsNullOrEmpty(targetSceneName))
        {
            Debug.LogWarning("遷移先シーンが設定されていません");
            return;
        }

        if (!Application.CanStreamedLevelBeLoaded(targetSceneName))
        {
            Debug.LogError($"Scene \"{targetSceneName}\" はBuild Settingsに登録されていません");
            return;
        }

        SceneManager.LoadScene(targetSceneName);
    }

    // ゲーム終了ボタン
    public void OnClickQuitGame()
    {
        Debug.Log("ゲームを終了します");

#if UNITY_EDITOR
        // エディタ上での再生停止
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // ビルド後のアプリ終了
        Application.Quit();
#endif
    }
}
