using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Item[] items;
    public Item [] seeds;
    public Equipment[] tools;
    private Dictionary<string, Item> nameToItemDict = new Dictionary<string, Item>();
    private Dictionary<string, RuleTile> nameToPlantDict = new Dictionary<string,RuleTile>(); 
    private Dictionary<string, Equipment> nameToToolDict = new Dictionary<string, Equipment>(); 


    private void Awake()
    {
        foreach(Item item in items)
        {
            AddItem(item);
        }
        foreach(Item item in seeds)
        {
            AddSeed(item);
            Debug.Log(item.data.itemName, nameToPlantDict[item.data.itemName]);
        }
        foreach(Equipment equip in tools)
        {
            AddTool(equip);
        }
    }

    private void AddItem(Item item)
    {
        if(!nameToItemDict.ContainsKey(item.data.itemName))
        {
            nameToItemDict.Add(item.data.itemName, item);
        }
    }

    public Item GetItemByName(string key)
    {
        if(nameToItemDict.ContainsKey(key))
        {
            return nameToItemDict[key]; 
        }
        return null;
    }


    private void AddTool(Equipment item)
    {
        if(!nameToToolDict.ContainsKey(item.name))
        {
            Debug.Log("adding " + item.name);
            nameToToolDict.Add(item.name, item);
        }
    }


    public Equipment GetToolByName(string key)
    {
        if(nameToToolDict.ContainsKey(key))
        {
            return nameToToolDict[key]; 
        }
        return null;
    }

    private void AddSeed(Item seed)
    {
        if(!nameToPlantDict.ContainsKey(seed.data.itemName))
        {
            nameToPlantDict.Add(seed.data.itemName, seed.plantVersion);
        }
    }


    public RuleTile GetSeedByName(string key)
    {
        if(nameToPlantDict.ContainsKey(key))
        {
            return nameToPlantDict[key]; 
        }
        return null;
    }
}
