using UnityEngine;
using UnityEngine.UIElements;

public class HumanAssembler : MonoBehaviour
{
    [Header("Attach Points")]
    [SerializeField] private Transform bodyRoot;
    [SerializeField] private Transform hairRoot;

    [Header("Gender Sets")]
    [SerializeField] private GenderSet[] genderSets;

    public void Assemble(HumanData data)
    {
        GenderSet set = GetGenderSet(data.gender);

        if (set == null) 
        {
            Debug.LogError($"GenderSet not found for {data.gender}");
            return;
        }

        GameObject body =
            data.bodyOverride != null ? data.bodyOverride : set.defaultBodyPrefab;

        GameObject hair =
            data.hairOverride != null ? data.hairOverride : set.defaultHairPrefab;

        FaceExpressionSet face =
            data.faceOverride != null ? data.faceOverride : set.defaultFaceSet;

        var faceController = GetComponentInChildren<FaceController>();

        InstantiateBodyPart(body, bodyRoot);
        InstantiateHairPart(hair, hairRoot);

        //if (faceController != null)
        //{
        //    faceController.Initialize(data.faceExpressionSet);
        //}
    }

    private GenderSet GetGenderSet(Gender gender)
    {
        foreach (var set in genderSets)
        {
            if (set.gender == gender) { return set; }
        }
        return null;
    }

    private void InstantiateBodyPart(GameObject prefab, Transform parent)
    {
        if(prefab == null) { return; }
        if(parent == null) { return; }

        var obj = Instantiate(prefab, parent);

        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.identity;
        obj.transform.localScale = Vector3.one;
    }

    private void InstantiateHairPart(GameObject prefab, Transform parent)
    {
        if(prefab == null) { return; }
        if(parent == null) { return; }

        var obj = Instantiate(prefab, parent);

        var anchor = obj.GetComponent<HairAnchor>();
        if (anchor != null) 
        {
            obj.transform.localPosition = anchor.localPosition;
            obj.transform.localRotation = Quaternion.Euler(anchor.localRotation);
            obj.transform.localScale = anchor.localScale;
        }
        else
        {
            // •ÛŒ¯
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
            obj.transform.localScale = Vector3.one;
        }
           
    }
}
