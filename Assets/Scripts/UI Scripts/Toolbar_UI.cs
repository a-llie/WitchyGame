using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbar_UI : MonoBehaviour
{
    [SerializeField] private List<Slot_UI> toolbarSlot = new List<Slot_UI>();

    public Player player;
    private Slot_UI selectedSlot;
    private int numToolSlots = 8;
    private int activeItem = 0;

    private void Start()
    {
        Refresh();  
        SelectSlot(0);
    }

    private void Update()
    {
        TrySelectSlot();
    }

    private void SelectSlot(int index)
    {
        if(toolbarSlot.Count == numToolSlots)
        {
           if (selectedSlot != null)
               selectedSlot.SetHighlight(false);
            selectedSlot = toolbarSlot[index];
            selectedSlot.SetHighlight(true); 
            activeItem = index;
            player.SwitchActiveItem(index);
        }
    }

    public void Refresh()
    {
            for(int i =0; i < toolbarSlot.Count; i++)
            {
                if (player.inventory.slots[i].itemName != "")
                  {
                    toolbarSlot[i].SetItem(player.inventory.slots[i]);
                }
                else{
                    toolbarSlot[i].SetEmpty();
                }
        }
    }


    private bool TrySelectSlot()
    {
        int number;
        if(Input.anyKeyDown && int.TryParse(Input.inputString, out number)) 
        {   
            if (number > 0 && number < 9)
            {
                SelectSlot(number - 1);
                return true;
            }
            return false;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (activeItem < 7)
                SelectSlot(++activeItem);
            else
            {
                SelectSlot(0);
            }            
            return true;
        }else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (activeItem > 0)
                SelectSlot(--activeItem);
            else
            {
                SelectSlot(7);
            }            
            return true;
        }
        return false; 
    }
}
