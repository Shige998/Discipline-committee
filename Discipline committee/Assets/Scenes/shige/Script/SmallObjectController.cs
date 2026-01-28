using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider))]
public class SmallObjectController : MonoBehaviour, IPointerClickHandler
{
    [Header("Object Data")]
    public SmallObjectData data;

    MeshFilter meshFilter;
    MeshRenderer meshRenderer;
    BoxCollider boxCollider;

    void Awake()
    {
        meshFilter = GetComponentInChildren<MeshFilter>();
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();

        if (meshFilter == null || meshRenderer == null)
            Debug.LogError("MeshFilter / MeshRenderer が見つかりません", this);
    }

    public void Apply(SmallObjectData d)
    {
        data = d;
        if (data == null) return;

        meshFilter.mesh = data.mesh;
        meshRenderer.material = data.material;
        transform.localScale = data.scale;
        transform.localRotation = Quaternion.Euler(data.rotation);

        FitColliderToMesh();
    }

    void FitColliderToMesh()
    {
        if (meshFilter == null || meshFilter.mesh == null) return;

        Bounds b = meshFilter.mesh.bounds;
        boxCollider.center = b.center;
        boxCollider.size = b.size;
        boxCollider.isTrigger = false;
    }

    // ← ここが EventSystem 経由のクリック
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log($"クリックされた: {gameObject.name}");

        if (data == null)
        {
            Debug.LogWarning("Data がありません", this);
            return;
        }

        bool result = JudgeManager.Instance.Judge(data);
        Debug.Log(result ? "正解！" : "不正解！");

        if (result && data.canRemove)
            Destroy(gameObject);
    }
}
