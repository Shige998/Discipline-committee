using UnityEngine;

public enum FaceExpressionType
{
    Normal,
    Happy,
    Angry,
    Sad
}

[CreateAssetMenu(
    fileName = "FaceExpressionSet",
    menuName = "Character/Face Expression Set"
)]
public class FaceExpressionSet : ScriptableObject
{
    public Gender gender;

    [Header("Face Textures")]
    public Material normal;
    public Material happy;
    public Material angry;
    public Material sad;

    public Material Get(FaceExpressionType type)
    {
        return type switch
        {
            FaceExpressionType.Normal => normal,
            FaceExpressionType.Happy => happy,
            FaceExpressionType.Angry => angry,
            FaceExpressionType.Sad => sad,
            _ => normal
        };
    }
}