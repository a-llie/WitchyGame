using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Inventory 
{
    [System.Serializable]
    public class Slot
    {
        public string itemName; 
        public int count; 
        public int maxAllowed; 
        public Sprite icon; 
        

        public Slot()
        {
            itemName = ""; 
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
                }
            }
        }
    }

    public List<Slot> slots = new List<Slot>(); 

    public Inventory(int numSlots)
    {
        for (int i = 0; i < numSlots; i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }

    public void Add(Item itemToAdd)
    {
        foreach(Slot slot in slots)
        {
            if(slot.itemName == itemToAdd.data.itemName && slot.canAddItem())
            {
                slot.AddItem(itemToAdd); 
                return;
            }
        }

        foreach(Slot slot in slots)
        {
            if (slot.itemName == "")
            {
                slot.AddItem(itemToAdd);
                return;
            }
        }
    }


    public void Remove(int index)
    {
        slots[index].RemoveItem();
    }


}