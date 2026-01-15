using UnityEngine;


[CreateAssetMenu(menuName = "Game/PlacementPattern")]
public class PlacementPattern : ScriptableObject
{
    public PlacementEntry[] placements;
}

[System.Serializable]
public class PlacementEntry
{
    public int standIndex;
    public int mountPointIndex;
    public SmallObjectData data;

    public Vector3 rotation;
}
