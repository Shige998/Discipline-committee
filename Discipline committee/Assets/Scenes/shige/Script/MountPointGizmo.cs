using UnityEngine;

public class MountPointGizmo : MonoBehaviour
{
    public float size = 0.1f;
    public Color color = Color.green;

    void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, size);
    }
}
