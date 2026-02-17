using UnityEngine;

public class ObjectStand : MonoBehaviour
{
    [SerializeField] Transform[] mountPoints;

        public Transform GetMountPoint(int index)
    {
        if (index < 0 || index >= mountPoints.Length)
            return null;

        return mountPoints[index];
    
    }

    
    
}
