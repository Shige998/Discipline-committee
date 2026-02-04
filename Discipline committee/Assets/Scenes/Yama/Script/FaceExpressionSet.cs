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
    public Texture2D normal;
    public Texture2D happy;
    public Texture2D angry;
    public Texture2D sad;

    public Texture2D Get(FaceExpressionType type)
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