using PurpleCable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : ElementDisplay
{
    private void Start()
    {
        GetComponent<SimpleAnimation>().StartAnimation();
    }
}
