using UnityEngine;

[CreateAssetMenu(
    fileName = "HumanData",
    menuName = "Character/Human Data"
)]
public class HumanData : ScriptableObject
{
    public Gender gender;

    [Header("Parts")]
    public GameObject bodyPrefab;
    public GameObject hairPrefab;
    public FaceExpressionSet faceExpressionSet;
}

public enum Gender
{
    Male,
    Female
}
