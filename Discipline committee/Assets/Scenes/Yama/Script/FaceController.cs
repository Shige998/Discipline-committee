using UnityEngine;

public class FaceController : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer bodyRenderer;

    private Material faceMaterial;
    private FaceExpressionSet expressionSet;

    //private static readonly int MainTex =
    //    Shader.PropertyToID("_BaseMap"); // Built-in‚È‚ç "_MainTex"

    private void Awake()
    {
        faceMaterial = bodyRenderer.material;
    }

    public void Initialize(FaceExpressionSet set)
    {
        expressionSet = set;
        SetExpression(FaceExpressionType.Normal);
    }

    public void SetExpression(FaceExpressionType type)
    {
        if (expressionSet == null) { return; }

        var mat = expressionSet.Get(type);
        var mats = bodyRenderer.materials;
        mats[0] = mat;
        bodyRenderer.materials = mats;
    }
}
