using UnityEngine;

public class Clothing : Item
{
    public enum ClothingType
    {
        None = 0,
        BlueSuit = 1,
        GreenSuit = 2,
        RedSuit = 3
    }

    public ClothingType Type { get; private set; }

    public Clothing(string name, Sprite icon, ClothingType type) : base(name, icon)
    {
        Type = type;
    }
}
