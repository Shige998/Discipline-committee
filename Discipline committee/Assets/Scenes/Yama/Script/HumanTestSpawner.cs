using UnityEngine;

public class HumanTestSpawner : MonoBehaviour
{
    [SerializeField] private HumanAssembler humanPrefab;
    [SerializeField] private HumanData testData;

    private void Start()
    {
        HumanAssembler human =
            Instantiate(humanPrefab, Vector3.zero, Quaternion.Euler(-90,0,180));

        human.Assemble(testData);
    }
}
