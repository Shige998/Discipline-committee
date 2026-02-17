using UnityEngine;

public class HumanAssembler : MonoBehaviour
{
    [Header("Attach Points")]
    [SerializeField] private Transform bodyRoot;
    [SerializeField] private Transform hairRoot;
    // 現在生成されているキャラの顔を保持する（ボタン用）
    private FaceController currentFace;

    public GameObject Assemble(HumanData data)
    {
        GameObject characterRoot = new GameObject("CharacterInstance");
        // 既存のキャラを消す（もし必要なら。今回は追加生成の前提）
        // foreach (Transform child in bodyRoot) Destroy(child.gameObject);

        // Body生成
        GameObject bodyObj = Instantiate(data.bodyPrefab, characterRoot.transform);
        bodyObj.transform.localPosition = Vector3.zero;
        bodyObj.transform.localRotation = Quaternion.identity;

        // Face生成
        currentFace = bodyObj.GetComponentInChildren<FaceController>();
        if (currentFace != null)
        {
            if (data.faceMaterial != null)
            {
                // 今回は直接マテリアルを流し込むか、SetDefault等を呼ぶ形にします
                currentFace.ApplyFaceManual(data.faceMaterial);
            }
        }

        // Hair生成
        if (data.hairPrefab != null)
        {
            GameObject hairObj = Instantiate(data.hairPrefab, characterRoot.transform);
            var anchor = hairObj.GetComponent<HairAnchor>();
            if (anchor != null)
            {
                hairObj.transform.localPosition = anchor.localPosition;
                hairObj.transform.localRotation = Quaternion.Euler(anchor.localRotation);
                hairObj.transform.localScale = anchor.localScale;
            }
        }
        return characterRoot;
    }

    // ボタンから呼ぶ用
    public void OnClickDefault() => currentFace?.SetDefault();
    public void OnClickSmile() => currentFace?.SetSmile();
    public void OnClickAngry() => currentFace?.SetAngry();
    public void OnClickSad() => currentFace?.SetSad();
}