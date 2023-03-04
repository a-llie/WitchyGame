using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Item[] items;
    public Tool[] tools;
    public Item [] seeds;
    private Dictionary<string, Item> nameToItemDict = new Dictionary<string, Item>();
    private Dictionary<string, Tool> nameToToolDict = new Dictionary<string, Tool>();
    private Dictionary<string, Item> nameToPlantDict = new Dictionary<string,Item>(); 

    private void Awake()
    {
        foreach(Item item in items)
        {
            AddItem(item);
        }
        foreach(Tool tool in tools)
        {
            AddTool(tool);
        }
        foreach(Item item in seeds)
        {
            AddSeed(item);
        }
        Debug.Log(nameToPlantDict["GarlicPlant"].data.itemName);
        Item garlicPlant = nameToPlantDict["GarlicPlant"];
        Instantiate(garlicPlant, new Vector2(0,0), Quaternion.identity);
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


    private void AddTool(Tool tool)
    {
        if(!nameToToolDict.ContainsKey(tool.toolData.toolName))
        {
            nameToToolDict.Add(tool.toolData.toolName, tool);
        }
    }

    public Tool GetToolByName(string key)
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
            nameToPlantDict.Add(seed.data.itemName, seed);
        }
    }


    public Item GetSeedByName(string key)
    {
        if(nameToPlantDict.ContainsKey(key))
        {
            return nameToPlantDict[key]; 
        }
        return null;
    }
}
