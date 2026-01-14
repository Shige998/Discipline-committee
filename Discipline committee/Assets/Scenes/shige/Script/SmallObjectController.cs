using UnityEngine;

public class SmallObjectController : MonoBehaviour
{
    [SerializeField] MeshFilter meshFilter;
    [SerializeField] MeshRenderer meshRenderer;

    public void Setup(SmallObjectData data)
    {
        meshFilter.sharedMesh = data.mesh;
        meshRenderer.sharedMaterial = data.material;
        transform.localScale = data.scale;
    }
}
