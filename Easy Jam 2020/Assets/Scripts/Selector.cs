using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    [SerializeField] Picker PickerPrefab = null;

    private void Start()
    {
        CreatePickers();
    }

    private void CreatePickers()
    {
        int x = 0;

        foreach (var elementDef in Elements.GetElements())
        {
            Picker picker = Instantiate(PickerPrefab, transform);
            picker.transform.localPosition = new Vector3(x, 0);
            picker.SetElement(elementDef);

            x += 2;
        }
    }
}
