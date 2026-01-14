using UnityEngine;

[CreateAssetMenu(menuName = "Game/SmallObjectPattern")]
public class  SmallObjectData : ScriptableObject 
{
    public Mesh mesh;
    public Material material;
    public Vector3 scale = Vector3.one;
    
}
