using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(BoxCollider))]
public class SmallObjectController : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private SmallObjectData data;

    MeshFilter meshFilter;
    MeshRenderer meshRenderer;
    BoxCollider boxCollider;

    void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();

        if (data != null)
        {
            ApplyData();
        }
    }

    /// <summary>
    /// DayGameManager などから呼ぶ用
    /// </summary>
    public void SetData(SmallObjectData newData)
    {
        data = newData;
        ApplyData();
    }

    void ApplyData()
    {
        if (data == null)
        {
            Debug.LogWarning("SmallObjectData が設定されていません", this);
            return;
        }

        // 見た目反映
        meshFilter.sharedMesh = data.mesh;
        meshRenderer.material = data.material;

        transform.localScale = data.scale;
        transform.localRotation = Quaternion.Euler(data.rotation);

        // Collider を Mesh にフィット
        FitColliderToMesh();
    }

    void FitColliderToMesh()
    {
        if (meshFilter.sharedMesh == null) return;

        Bounds b = meshFilter.sharedMesh.bounds;
        boxCollider.center = b.center;
        boxCollider.size = b.size;
        boxCollider.isTrigger = false;
    }

    // ─────────────
    // クリック判定（BoxCollider 使用）
    // ─────────────
    void OnMouseDown()
    {
        Debug.Log($"クリックされました: {gameObject.name}");

        // 将来 Judge / Remove 処理をここに追加できる
        if (data != null && data.canRemove)
        {
            // 仮：削除例
            // Destroy(gameObject);
        }
    }
}
