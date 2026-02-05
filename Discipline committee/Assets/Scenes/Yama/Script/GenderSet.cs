using UnityEngine;

[CreateAssetMenu(
    fileName = "GenderSet",
    menuName = "Character/Gender Set"
)]
public class GenderSet : ScriptableObject
{
    public Gender gender;

    [Header("Default Parts")]
    public GameObject defaultBodyPrefab;
    public GameObject defaultHairPrefab;
    public FaceExpressionSet defaultFaceSet;
}
