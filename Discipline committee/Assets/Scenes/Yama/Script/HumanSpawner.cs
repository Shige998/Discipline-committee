using UnityEngine;

public class HumanSpawner : MonoBehaviour
{
    [SerializeField] private HumanAssembler humanPrefab;

    public void Spawn(HumanData data, Vector3 position)
    {
        var human = Instantiate(humanPrefab, position, Quaternion.identity);
        human.Assemble(data);
    }
}
