using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Crop Data", menuName = "Crop Data", order = 50)]
public class CropData : ScriptableObject
{
    public int daysToGrow;
    public Sprite[] stageSprites;
    public Sprite[] harvestSprite;

}

