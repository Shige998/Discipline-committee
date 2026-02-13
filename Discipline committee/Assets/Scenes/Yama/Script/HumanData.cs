using UnityEngine;

[CreateAssetMenu(
    fileName = "HumanData",
    menuName = "Character/Human Data"
)]
public class HumanData : ScriptableObject
{

    [Header("Parts")]
    public GameObject bodyPrefab;
    public GameObject hairPrefab;

    [Header("Face")]
    public Material faceMaterial;
}
