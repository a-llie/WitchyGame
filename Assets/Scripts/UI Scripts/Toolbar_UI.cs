using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbar_UI : MonoBehaviour
{
    [SerializeField] private List<Slot_UI> toolbarSlot = new List<Slot_UI>();

    private Slot_UI selectedSlot;
    private int numToolSlots = 8;
    private int currSlot = 0;

    private void Start()
    {
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
               selectedSlot.SetHighlight();
            selectedSlot = toolbarSlot[index];
            selectedSlot.SetHighlight(); 
            currSlot = index;
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
            if (currSlot < 7)
                SelectSlot(++currSlot);
            else
            {
                SelectSlot(0);
            }            
            return true;
        }else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currSlot > 0)
                SelectSlot(--currSlot);
            else
            {
                SelectSlot(7);
            }            
            return true;
        }
        return false; 
    }
}
