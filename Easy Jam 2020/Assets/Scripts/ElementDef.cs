using UnityEngine;

[CreateAssetMenu(fileName = "Element", menuName = "Element")]
public class ElementDef : ScriptableObject
{
    public ElementType ElementType = ElementType.None;

    public Color Color = Color.white;

    public Sprite Sprite = null;

    public override string ToString()
    {
        return ElementType.ToString();
    }
}
