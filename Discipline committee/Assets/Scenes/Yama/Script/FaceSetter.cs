using UnityEngine;

public class FaceSetter : MonoBehaviour
{
    [SerializeField] private SpriteRenderer faceRenderer;
    [SerializeField] private FaceData faceData;

    void Start()
    {
        ApplyFace();
    }

    public void ApplyFace()
    {
        if (faceRenderer == null)
        {
            Debug.LogError("faceRenderer Ç™ñ¢ê›íË");
            return;
        }

        if (faceData == null || faceData.faceMaterial == null)
        {
            Debug.LogError("FaceData Ç‹ÇΩÇÕ Material Ç™ñ¢ê›íË");
            return;
        }

        faceRenderer.material = faceData.faceMaterial;
        Debug.Log("Face material applied");
    }
}
