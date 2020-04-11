using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[DisallowMultipleComponent]
public class Elements : MonoBehaviour
{
    private static Dictionary<ElementType, ElementDef> ElementDefs;

    private void Awake()
    {
        ElementDefs = Resources.LoadAll<ElementDef>("Elements").ToDictionary(x => x.ElementType, y => y);
    }

    public static ElementDef GetRandomElement()
    {
        return ElementDefs.Values.ToArray().GetRandom();
    }

    public static IEnumerable<ElementDef> GetElements()
    {
        foreach (var elementDef in ElementDefs.Values)
        {
            yield return elementDef;
        }
    }
}
