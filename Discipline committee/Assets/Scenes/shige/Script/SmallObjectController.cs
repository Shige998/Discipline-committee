using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SmallObjectController : MonoBehaviour
{
    public SmallObjectData data;

    // DayGameManager ‚©‚çŒÄ‚Î‚ê‚é
    public void Apply(SmallObjectData d)
    {
        data = d;

        var mf = GetComponentInChildren<MeshFilter>();
        var mr = GetComponentInChildren<MeshRenderer>();

        if (mf == null || mr == null)
        {
            Debug.LogError("MeshFilter / MeshRenderer ‚ªŒ©‚Â‚©‚è‚Ü‚¹‚ñ", this);
            return;
        }

        mf.mesh = d.mesh;
        mr.material = d.material;

        transform.localScale = d.scale;
        transform.localRotation = Quaternion.Euler(d.rotation);

        FitColliderToMesh();
    }

    void FitColliderToMesh()
    {
        var mf = GetComponentInChildren<MeshFilter>();
        var col = GetComponent<BoxCollider>();

        if (mf == null || mf.mesh == null || col == null) return;

        Bounds b = mf.mesh.bounds;
        col.center = b.center;
        col.size = b.size;
    }

    // Button ‚©‚çŒÄ‚Î‚ê‚é
    public void OnClick()
    {
        if (data == null)
        {
            Debug.LogWarning("Data ‚ª‚ ‚è‚Ü‚¹‚ñ", this);
            return;
        }

        bool result = JudgeManager.Instance.Judge(data);
        Debug.Log(result ? "³‰ğI" : "•s³‰ğI");
    }
}
