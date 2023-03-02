using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlots : MonoBehaviour
{

    public Slot_UI slot; 
    // Start is called before the first frame update
    void Start()
    {
        addSlots();
    }


    private void addSlots()
    {
        Player player = GameManager.instance.inventoryUI.player;
        //slot = GetComponent<Slot_UI>();
        for (int i = 0; i < player.inventory.slots.Count; i++)
        {
            Slot_UI newSlot = Instantiate(slot, transform);
            newSlot.SetEmpty();
            newSlot.SetButtonOnClick(i);
            newSlot.setIndex(i);
            GameManager.instance.inventoryUI.slots.Add(newSlot);
        }
    }

}
