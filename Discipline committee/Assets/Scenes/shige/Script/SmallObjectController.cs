using UnityEngine;

public class SmallObjectController : MonoBehaviour
{
    [SerializeField] private MeshFilter meshFilter;
    [SerializeField] private MeshRenderer meshRenderer;

    private SmallObjectData data;

    public void Apply(SmallObjectData data)
    {
        this.data = data;

        meshFilter.mesh = data.mesh;
        meshRenderer.material = data.material;

        transform.localScale = data.scale;
        transform.localRotation = Quaternion.Euler(data.rotation);
    }

    void OnMouseDown()
    {
        if (data == null)
        {
            Debug.LogWarning("SmallObjectData ‚ªİ’è‚³‚ê‚Ä‚¢‚Ü‚¹‚ñ");
            return;
        }

        if (data.canRemove)
        {
            Debug.Log($"y³‰ğz{data.displayName} ‚ÍÁ‚µ‚ÄOK");
        }
        else
        {
            Debug.Log($"y•s³‰ğz{data.displayName} ‚ÍÁ‚µ‚ÄNG");
        }
    }
}
