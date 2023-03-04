using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Item[] items;
    public Item [] seeds;
    private Dictionary<string, Item> nameToItemDict = new Dictionary<string, Item>();
    private Dictionary<string, RuleTile> nameToPlantDict = new Dictionary<string,RuleTile>(); 

    private void Awake()
    {
        foreach(Item item in items)
        {
            AddItem(item);
        }
        foreach(Item item in seeds)
        {
            AddSeed(item);
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


    private void AddSeed(Item seed)
    {
        if(!nameToPlantDict.ContainsKey(seed.data.itemName))
        {
            nameToPlantDict.Add(seed.data.itemName, seed.asPlant);
        }
    }


    public RuleTile GetSeedByName(string key)
    {
        if(nameToPlantDict.ContainsKey(key))
        {
            return nameToPlantDict[key]; 
        }
        Debug.Log("no key w/ that name");
        return null;
    }
}
