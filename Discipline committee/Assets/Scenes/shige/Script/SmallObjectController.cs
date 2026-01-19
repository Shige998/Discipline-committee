using UnityEngine;

public class SmallObjectController : MonoBehaviour
{
    [SerializeField] MeshFilter meshFilter;
    [SerializeField] MeshRenderer meshRenderer;

    [SerializeField]private SmallObjectData data;

        void Awake()
    {
    }

    public void Apply(SmallObjectData data)
    {
        this.data = data;
        meshFilter.mesh = data.mesh;
        meshRenderer.material = data.material;

        transform.localScale = data.scale;
        transform.localRotation = Quaternion.Euler(data.rotation);
    }

    void OnMouseDown()
    {
        if (data == null)
        {
            Debug.LogWarning("SmallObjectData‚ªİ’è‚³‚ê‚Ä‚¢‚Ü‚¹‚ñ");
            return;
        }

        if (JudgeManager.Instance == null)
        {
            Debug.LogWarning("JudgeManager ‚ª‘¶İ‚µ‚Ü‚¹‚ñ");
            return;
        }

        bool result = JudgeManager.Instance.Judge(data);

        if (result)
        {
            Debug.Log($"yOKz{data.name}‚ÍÁ‚µ‚Ä‚¢‚¢");
        }
        else
        {
            Debug.Log($"yNGz{data.name}‚ÍÁ‚µ‚Ä‚Í‚¢‚¯‚È‚¢");
        }
    }
}
