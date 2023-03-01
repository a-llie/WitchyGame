using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public int curDay;
    public int money;
    public int cropInventory;
    public ItemData selectedCropToPlant;
    public int harvestInventory; 
    public event UnityAction onNewDay;
    

    // Singleton
    public static GameManager instance;
    public ItemManager itemManager;
    public TileManager tileManager; 
    public Inventory_UI inventoryUI;
    

    private void Awake ()
    {
        // Initialize the singleton.
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
        itemManager = GetComponent<ItemManager>();
        tileManager = GetComponent<TileManager>();
        inventoryUI = GetComponent<Inventory_UI>();
    }


    public void OnPlantCrop(ItemData crop)
    {
        cropInventory--;
    }


    public void OnHarvestCrop(ItemData crop)
    {
        harvestInventory++;
    }

    public void OnSellCrop(ItemData crop)
    {

    }   

    public void OnBuyCrop(ItemData crop)
    {

    }

    public void CanPlantCrop(ItemData crop)
    {

    }

    public void OnBuyCropButton(ItemData crop)
    {

    }
    
    void OnEnable ()
    {
        Item.onPlantCrop += OnPlantCrop;
        Item.onHarvestCrop += OnHarvestCrop;
    }
    void OnDisable ()
    {
        Item.onPlantCrop -= OnPlantCrop;
        Item.onHarvestCrop -= OnHarvestCrop;
    }

}
