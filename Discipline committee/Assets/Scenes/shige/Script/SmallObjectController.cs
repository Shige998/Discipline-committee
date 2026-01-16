using UnityEngine;

public class SmallObjectController : MonoBehaviour
{
    [SerializeField] MeshFilter meshFilter;
    [SerializeField] MeshRenderer meshRenderer;

    private string objectName;
        void Awake()
    {
        objectName = gameObject.name;
    }

    public void Apply(SmallObjectData data)
    {
        meshFilter.mesh = data.mesh;
        meshRenderer.material = data.material;

        transform.localScale = data.scale;
        transform.localRotation = Quaternion.Euler(data.rotation);
    }
}
