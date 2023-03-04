using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;


public class Slot_UI : MonoBehaviour
{
    // Start is called before the first frame update
    public Image itemIcon;
    public TextMeshProUGUI quantityText; 
    [SerializeField] private GameObject highlight;
    private int index; 
    private EventTrigger trigger;

    public void Start()
    {   
        if (gameObject.tag == "InventorySlot")
        {
            trigger = GetComponent<EventTrigger>();
            EventTrigger.Entry beginDrag = new EventTrigger.Entry();
            beginDrag.eventID = EventTriggerType.BeginDrag;
            beginDrag.callback.AddListener((data) => { GameManager.instance.inventoryUI.SlotBeginDrag(this); });
            trigger.triggers.Add(beginDrag);

            EventTrigger.Entry drag = new EventTrigger.Entry();
            drag.eventID = EventTriggerType.Drag;
            drag.callback.AddListener((data) => { GameManager.instance.inventoryUI.SlotDrag(); });
            trigger.triggers.Add(drag);

            EventTrigger.Entry endDrag = new EventTrigger.Entry();
            endDrag.eventID = EventTriggerType.EndDrag;
            endDrag.callback.AddListener((data) => { GameManager.instance.inventoryUI.SlotEndDrag(); });
            trigger.triggers.Add(endDrag);


            EventTrigger.Entry drop = new EventTrigger.Entry();
            drop.eventID = EventTriggerType.Drop;
            drop.callback.AddListener((data) => { GameManager.instance.inventoryUI.SlotDrop(this); });
            trigger.triggers.Add(drop);
        }
        


    }


    public void SetItem(Inventory.Slot slot)
    {
        if(slot != null)
        { 
            itemIcon.sprite = slot.icon;
            itemIcon.color = new Color(1,1,1,1);
            quantityText.text = slot.count.ToString();
            transform.GetChild(2).gameObject.SetActive(true);
            //gameObject.SetActive(true);
        }
    }


    public void SetEmpty()
    {
        itemIcon.sprite = null; 
        itemIcon.color = new Color(1,1,1,0); 
        quantityText.text = "";
        transform.GetChild(2).gameObject.SetActive(false);
        //gameObject.SetActive(false);
    }

    public bool IsEmpty()
    {
        return itemIcon.sprite == null;
    }

    public void SetHighlight(bool set)
    {
        highlight.SetActive(set);
    }
    
    public void SetButtonOnClick(int index)
    {
        transform.GetChild(2).gameObject.GetComponent<InvRemoveButton>().SetIndex(index);
    }

    public void setIndex(int index)
    {
        this.index = index;
    }

    public int getIndex()
    {
        return index;
    }
}
