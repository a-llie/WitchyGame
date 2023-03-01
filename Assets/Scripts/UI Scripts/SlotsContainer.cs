using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotsContainer : MonoBehaviour
{
    public Slot_UI slotPrefab;
    public Player player;
    
    private void Awake()
    {
        Slot_UI slotCutter  = GetComponentInChildren<Slot_UI>();
        slotCutter.transform.GetChild(2).gameObject.GetComponent<DropItemButton>().index = 0;
        slotCutter.transform.GetChild(2).gameObject.GetComponent<Button>().onClick.AddListener(slotCutter.OnDropItemButton);
        player = FindObjectOfType<Player>();
        //instantiate slots 
        Debug.Log(player.inventorySize);
        for(int i =1; i < player.inventorySize; i++)
        {
            Slot_UI slot = Instantiate(slotCutter, transform);
            Debug.Log(slot.transform.GetChild(2).gameObject.GetComponent<Button>().name);
            slot.transform.GetChild(2).gameObject.GetComponent<DropItemButton>().index = i;
            slot.transform.GetChild(2).gameObject.GetComponent<Button>().onClick.AddListener(slot.OnDropItemButton);
        }
    }
}
