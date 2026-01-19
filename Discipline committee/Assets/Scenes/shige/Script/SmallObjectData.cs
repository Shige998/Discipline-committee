using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(menuName = "SmallObject/Data")]
public class  SmallObjectData : ScriptableObject 
{

    public string displayName;
    public Mesh mesh;
    public Material material;
    public Vector3 scale = Vector3.one;
    public Vector3 rotation;

    [Header("Jidge")]
    public PatternType pattern;
    public bool canRemove;
}
