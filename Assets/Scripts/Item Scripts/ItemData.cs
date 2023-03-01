using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Item Data", menuName = "Item Data", order = 50)]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public int daysToGrow;
    public Sprite[] growProgressSprites;
    public Sprite readyToHarvestSprite;

    public int purchasePrice;
    public int sellPrice;
}
