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

       
    }

    public void Apply(SmallObjectData d)
    {
        data = d;
        if (data == null) return;

        meshFilter.mesh = d.mesh;
        meshRenderer.material = d.material;
        transform.localScale = d.scale;
        transform.localRotation = Quaternion.Euler(d.rotation);

        FitColliderToMesh();
    }

    void FitColliderToMesh()
    {
        

        Bounds b = meshFilter.mesh.bounds;
        boxCollider.center = b.center;
        boxCollider.size = b.size;
    }

    // ← ここが EventSystem 経由のクリック
    public void OnPointerClick(PointerEventData eventData)
    {
        Judge();
    }

    void Judge()
    {
        if (data == null) return;

        KarmaManager.Instance.AddKarma(data.karmaValue);

        Debug.Log(data.resultType == ObjectResultType.Correct ? "正解！" : "不正解!");

        //前まで一部しか消えないようにしていたため修正しています
        Destroy(gameObject);
    }
}
