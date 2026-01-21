using UnityEngine;

[CreateAssetMenu(menuName = "SmallObject/Data")]
public class SmallObjectData : ScriptableObject
{
    [Header("表示名")]
    public string displayName;

    [Header("見た目")]
    public Mesh mesh;
    public Material material;

    [Header("Transform")]
    public Vector3 scale = Vector3.one;
    public Vector3 rotation;

    [Header("配置補正")]
    public float heightOffset = 0.5f;   // ★ 追加（台座からの高さ）

    [Header("判定")]
    public bool canRemove;
}
