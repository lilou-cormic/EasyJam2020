using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementDisplay : MonoBehaviour
{
    [SerializeField] SpriteRenderer SpriteRenderer = null;

    protected ElementDef ElementDef { get; private set; }

    public ElementType ElementType => ElementDef?.ElementType ?? ElementType.None;

    public void SetElement(ElementDef elementDef)
    {
        ElementDef = elementDef;

        SpriteRenderer.sprite = ElementDef.Sprite;
        SpriteRenderer.color = ElementDef.Color;
    }
}
