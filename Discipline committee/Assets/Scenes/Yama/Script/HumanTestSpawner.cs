using UnityEngine;

public class HumanTestSpawner : MonoBehaviour
{
    [SerializeField] private HumanAssembler humanPrefab;
    [SerializeField] private HumanData testData;

    [SerializeField] public Vector3 spawnPos = new Vector3(0f, 0f, 0f);

    private void Start()
    {
        HumanAssembler human =
            Instantiate(humanPrefab, spawnPos, Quaternion.Euler(-90,0,180));

        human.Assemble(testData);
    }
}
