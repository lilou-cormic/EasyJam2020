using PurpleCable;
using System;
using UnityEngine;

public class Picker : ElementDisplay
{
    [SerializeField] AudioClip ClickSound = null;

    public static event Action<ElementDef> ElementPicked;

    private void OnMouseDown()
    {
        ClickSound.Play();

        ElementPicked?.Invoke(ElementDef);

        foreach (var animation in GetComponents<SimpleAnimation>())
        {
            animation.StartAnimation();
        }
    }
}
