using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    //public int curDay;
    //public int money;
    //public int cropInventory;
    //public int harvestInventory; 
    

    // Singleton
    public static GameManager instance;
    public ItemManager itemManager;
    public TileManager tileManager; 
    public Inventory_UI inventoryUI;
    public Toolbar_UI toolbarUI;

    public Player player;

    public string itemManString = "ItemManager";

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
        toolbarUI = GetComponent<Toolbar_UI>();
    }

}
