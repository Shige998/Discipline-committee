using UnityEngine;

[CreateAssetMenu(
    fileName = "HumanData",
    menuName = "Character/Human Data"
)]
public class HumanData : ScriptableObject
{
    public Gender gender;

    [Header("Default Parts")]
    public GameObject bodyOverride;
    public GameObject hairOverride;
    public FaceExpressionSet faceOverride;
}

public enum Gender
{
    Boy,
    Girl
}
