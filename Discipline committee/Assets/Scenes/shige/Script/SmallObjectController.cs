using UnityEngine;

public class SmallObjectController : MonoBehaviour
{
    [SerializeField] MeshFilter meshFilter;
    [SerializeField] MeshRenderer meshRenderer;

    [SerializeField]private SmallObjectData data;

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

    void OnMouseDown()
    {
        if (data == null)
        {
            Debug.LogWarning("SmallObjectDataÇ™ê›íËÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒ");
            return;
        }

        if (data.canRemove)
        {
            Debug.Log($"ÅyOKÅz{data.name}ÇÕè¡ÇµÇƒÇ¢Ç¢");
        }
        else
        {
            Debug.Log($"ÅyNGÅz{data.name}ÇÕè¡ÇµÇƒÇÕÇ¢ÇØÇ»Ç¢");
        }
    }
}
