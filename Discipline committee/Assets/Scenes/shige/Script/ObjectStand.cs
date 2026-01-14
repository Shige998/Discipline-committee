using UnityEngine;

public class ObjectStand : MonoBehaviour
{
    [SerializeField] Transform mountPoint;

    public void Place (SmallObjectController obj)
    {
        obj.transform.SetParent(mountPoint);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.identity;
    }
}
