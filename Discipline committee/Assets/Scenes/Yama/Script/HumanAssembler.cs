using UnityEngine;

public class HumanAssembler : MonoBehaviour
{
    [Header("Attach Points")]
    [SerializeField] private Transform bodyRoot;
    [SerializeField] private Transform hairRoot;

    // 現在生成されているキャラの顔を保持する（ボタン用）
    private FaceController currentFace;

    public void Assemble(HumanData data)
    {
        // 既存のキャラを消す（もし必要なら。今回は追加生成の前提）
        // foreach (Transform child in bodyRoot) Destroy(child.gameObject);

        // --- 1. Body を生成 ---
        GameObject bodyObj = Instantiate(data.bodyPrefab, bodyRoot);
        bodyObj.transform.localPosition = Vector3.zero;
        bodyObj.transform.localRotation = Quaternion.identity;

        // --- 2. FaceController の初期設定 ---
        currentFace = bodyObj.GetComponentInChildren<FaceController>();
        if (currentFace != null)
        {
            // ここがポイント：SOに設定された顔を強制的に適用する
            if (data.faceMaterial != null)
            {
                // FaceControllerに新しいメソッド「Initialize」を作ると綺麗ですが、
                // 今回は直接マテリアルを流し込むか、SetDefault等を呼ぶ形にします
                currentFace.ApplyFaceManual(data.faceMaterial);
            }
        }
        else
        {
            Debug.LogError($"{bodyObj.name} に FaceController が付いていません！");
        }

        // --- 3. Hair を生成 ---
        if (data.hairPrefab != null)
        {
            GameObject hairObj = Instantiate(data.hairPrefab, hairRoot);
            var anchor = hairObj.GetComponent<HairAnchor>();
            if (anchor != null)
            {
                hairObj.transform.localPosition = anchor.localPosition;
                hairObj.transform.localRotation = Quaternion.Euler(anchor.localRotation);
                hairObj.transform.localScale = anchor.localScale;
            }
        }
    }

    // ボタンから呼ぶ用
    public void OnClickDefault() => currentFace?.SetDefault();
    public void OnClickSmile() => currentFace?.SetSmile();
    public void OnClickAngry() => currentFace?.SetAngry();
    public void OnClickSad() => currentFace?.SetSad();
}