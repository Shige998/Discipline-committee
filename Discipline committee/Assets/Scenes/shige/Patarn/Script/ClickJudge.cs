using UnityEngine;

public class ClickJudge : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log($"Clicked: {gameObject.name}");

        Destroy(gameObject);
    }
}
