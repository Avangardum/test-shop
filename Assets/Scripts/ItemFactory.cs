using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : MonoBehaviour
{
    [SerializeField] private Sprite blueSuitSprite;
    [SerializeField] private Sprite greenSuitSprite;
    [SerializeField] private Sprite redSuitSprite;
    
    public Clothing CreateBlueSuit() => new Clothing("Blue suit", blueSuitSprite, Clothing.ClothingType.BlueSuit);
    public Clothing CreateGreenSuit() => new Clothing("Green suit", greenSuitSprite, Clothing.ClothingType.GreenSuit);
    public Clothing CreateRedSuit() => new Clothing("Red suit", redSuitSprite, Clothing.ClothingType.RedSuit);
}
