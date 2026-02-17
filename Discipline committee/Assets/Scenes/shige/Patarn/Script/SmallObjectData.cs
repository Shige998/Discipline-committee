using UnityEngine;

public enum ObjectResultType
{
    Correct,
    Wrong
}
[CreateAssetMenu(menuName = "SmallObject/Data")]
public class SmallObjectData : ScriptableObject
{
    public string displayName;
    public Mesh mesh;
    public Material material;
    public Vector3 scale = Vector3.one;
    public Vector3 rotation;
    [Header("”»’è")]
    public ObjectResultType resultType;

    [Header("ƒJƒ‹ƒ}•Ï“®—Ê")]
    public int karmaValue;
}
