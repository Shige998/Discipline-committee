using UnityEngine;

public class HumanAssembler : MonoBehaviour
{
    [Header("Attach Points")]
    [SerializeField] private Transform bodyRoot;
    [SerializeField] private Transform hairRoot;

    public void Assemble(HumanData data)
    {
        InstantiatePart(data.bodyPrefab, bodyRoot);
        InstantiatePart(data.hairPrefab, hairRoot);

        var faceController = GetComponentInChildren<FaceController>();
        if (faceController != null)
        {
            faceController.Initialize(data.faceExpressionSet);
        }
    }

    private void InstantiatePart(GameObject prefab, Transform parent)
    {
        if(prefab == null) { return; }
        if(parent == null) { return; }
        var obj = Instantiate(prefab, parent);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.identity;
        obj.transform.localScale = Vector3.one;
    }
}
