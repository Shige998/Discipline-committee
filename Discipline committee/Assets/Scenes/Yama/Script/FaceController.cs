using UnityEngine;

public class FaceController : MonoBehaviour
{
    [Header("顔を表示するRenderer")]
    [SerializeField] public SkinnedMeshRenderer faceRenderer;

    [Header("表情マテリアル")]
    public Material defaultface;
    public Material smileface;
    public Material angryface;
    public Material sadface;

    //private static readonly int MainTex =
    //    Shader.PropertyToID("_BaseMap"); // Built-inなら "_MainTex"

    public void SetDefault()
    {
        Debug.Log("SetDefault");
        ApplyFace(defaultface);
    }
    public void SetSmile()
    {
        ApplyFace(smileface);
    }
    public void SetAngry()
    {
        Debug.Log("SetAngry");
        ApplyFace(angryface);
    }
    public void SetSad()
    {
        ApplyFace(sadface);
    }

    void ApplyFace(Material mat)
    {
        if (faceRenderer == null || mat == null) return;

        // 全てのスロットをそのマテリアルに変えてみる（テスト用）
        Material[] mats = new Material[faceRenderer.sharedMaterials.Length];
        for (int i = 0; i < mats.Length; i++)
        {
            mats[i] = mat;
        }
        faceRenderer.materials = mats;

        Debug.Log($"{faceRenderer.gameObject.name} のマテリアルを {mat.name} に変更しました");
    }

    public void ApplyFaceManual(Material mat)
    {
        if (faceRenderer != null && mat != null)
        {
            faceRenderer.material = mat;
        }
    }
    //public void Initialize(FaceExpressionSet set)
    //{
    //    expressionSet = set;
    //    SetExpression(FaceExpressionType.Normal);
    //}

    //public void SetExpression(FaceExpressionType type)
    //{
    //    if (expressionSet == null) { return; }

    //    var mat = expressionSet.Get(type);
    //    var mats = bodyRenderer.materials;
    //    mats[0] = mat;
    //    bodyRenderer.materials = mats;
    //}
}
