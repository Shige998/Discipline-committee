using UnityEngine;

public class ClickJudge : MonoBehaviour
{
    void Update()
    {
        // 左クリック
        if (!Input.GetMouseButtonDown(0)) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Colliderが付いている親を探す
            SmallObjectController obj =
                hit.collider.GetComponentInParent<SmallObjectController>();

            if (obj == null) return;

            bool result = JudgeManager.Instance.Judge(obj.data);

            Debug.Log(result ? "正解" : "不正解");

            if (result)
            {
                Destroy(obj.gameObject);
            }
        }
    }
}
