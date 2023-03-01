using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    public ItemData data;

    [HideInInspector] public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private int plantDay;
    private int daysSinceLastWatered; 

    public SpriteRenderer sr; 

    public static event UnityAction<ItemData> onPlantCrop;
    public static event UnityAction<ItemData> onHarvestCrop;



    public void Plant (ItemData crop)
    {
        data = crop;
        plantDay = GameManager.instance.curDay;
        daysSinceLastWatered = 1;
        UpdateCropSprite();
        onPlantCrop?.Invoke(crop);
    }


    // Returns the number of days that the crop has been planted for.
    int CropProgress ()
    {
        return GameManager.instance.curDay - plantDay;
    }
    // Can we currently harvest the crop?
    public bool CanHarvest ()
    {
        return CropProgress() >= data.daysToGrow;
    }

    // Called when the crop has been watered.
    public void Water ()
    {
        daysSinceLastWatered = 0;
    }
    // Called when we want to harvest the crop.
    public void Harvest ()
    {
        if(CanHarvest())
        {
            onHarvestCrop?.Invoke(data);
            Destroy(gameObject);
        }
    }

    // Called when the crop has progressed.
    void UpdateCropSprite ()
    {
        int cropProg = CropProgress();
        if(cropProg < data.daysToGrow)
        {
            sr.sprite = data.growProgressSprites[cropProg];
        }
        else
        {
            sr.sprite = data.readyToHarvestSprite;
        }
    }

    
    // Called when a new day ticks over.
    public void NewDayCheck ()
    {
        daysSinceLastWatered++;
        if(daysSinceLastWatered > 3)
        {
            Destroy(gameObject);
        }
        UpdateCropSprite();
    }
}
