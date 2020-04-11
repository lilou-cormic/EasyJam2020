using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picker : ElementDisplay
{
    public static event Action<ElementDef> ElementPicked;

    private void OnMouseDown()
    {
        ElementPicked?.Invoke(ElementDef);
    }
}
