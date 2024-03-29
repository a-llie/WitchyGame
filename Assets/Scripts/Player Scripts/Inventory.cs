using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Inventory 
{
    public int toolbarSize = 8;
    [System.Serializable]
    public class Slot
    {
        public string itemName; 
        public string equipmentName; 
        public int count; 
        public int maxAllowed; 
        public Sprite icon; 
        

        public Slot()
        {
            itemName = ""; 
            equipmentName = "";
            count = 0;
            maxAllowed = 99; 
        }

        public bool canAddItem()
        {
            if (count < maxAllowed)
            { 
                return true;
            }
            return false;
        }

        public void AddItem(Item item)
        {
            this.itemName = item.data.itemName; 
            this.equipmentName = item.data.equipmentName; 
            this.icon = item.data.icon;
            count++; 
        }

        public void RemoveItem()
        {
            if (count > 0)
            {
                count--;
                if (count == 0)
                {
                    icon = null;
                    itemName = "";
                    equipmentName = "";
                }
            }
        }
    }

    public List<Slot> slots = new List<Slot>(); 
    public List<Slot> equipped = new List<Slot>();

    //creating slots for inventory and toolbar 
    public Inventory(int numSlots)
    {
        for (int i = 0; i < numSlots; i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
        for (int i = 0; i < toolbarSize; i++)
        {
            Slot slot = new Slot();
            equipped.Add(slot);
        }
    }


    //add items to array data structure 
    public bool Add(Item itemToAdd)
    {
        int i = 0;
        //add to stack if there is one
        foreach(Slot slot in slots)
        {
            if(slot.itemName == itemToAdd.data.itemName && slot.canAddItem())
            {
                slot.AddItem(itemToAdd); 
                if (i < toolbarSize)
                {
                    equipped[i].AddItem(itemToAdd);         
                }
                return true;
            }
            i++;
        }
        i = 0; 
        //otherwise, add to an empty available slot 
        foreach(Slot slot in slots)
        {
            if (slot.itemName == "")
            {
                slot.maxAllowed = itemToAdd.data.maxAllowed; 
                slot.AddItem(itemToAdd);
                if (i < toolbarSize)
                {
                    equipped[i].AddItem(itemToAdd);
                    if (i == GameManager.instance.player.activeItemIndex)
                        GameManager.instance.player.SwitchActiveItem(i);
                }
                return true;
            }
            i++;
        }

        return false;
    }


    //remove from inventory and toolbar if applicable 
    public void Remove(int index)
    {
        slots[index].RemoveItem();
        if (index < toolbarSize)
        {
            equipped[index].RemoveItem();
        }
    }

    public void Swap(int index1, int index2)
    {
        Slot temp = slots[index1];
        slots[index1] = slots[index2];
        slots[index2] = temp;
        if (index1 < toolbarSize)
        {
            equipped[index1] = slots[index1];
        }
        if (index2 < toolbarSize)
        {
            equipped[index2] = slots[index2];
        }

        GameManager.instance.player.SwitchActiveItem(GameManager.instance.player.activeItemIndex);
        
    }

}
