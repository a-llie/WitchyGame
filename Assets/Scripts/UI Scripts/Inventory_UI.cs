using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_UI : MonoBehaviour
{
    public Player player;
    public List<Slot_UI> slots = new List<Slot_UI>();

    [SerializeField] private Canvas canvas;

    public GameObject inventoryPanel;
    private Slot_UI dragSlot;
    private Image dragImage;

    

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>();
        inventoryPanel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();    
        }
    }

    public void ToggleInventory()
    {
        if (!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
            Refresh();
        }
        else
        {
            inventoryPanel.SetActive(false);
        }
    }


    void Refresh()
    {
        if(slots.Count == player.inventory.slots.Count)
        {
            for(int i =0; i < slots.Count; i++)
            {
                if (player.inventory.slots[i].itemName != "")
                  {
                    slots[i].SetItem(player.inventory.slots[i]);
                }
                else{
                    slots[i].SetEmpty();
                }
            }
        }
    }


    public void Remove(int slotID)
    {
        Item itemToDrop = GameManager.instance.itemManager.GetItemByName(player.inventory.slots[slotID].itemName);
        Debug.Log(itemToDrop);
        if (itemToDrop !=null)
        {
            player.DropItem(itemToDrop);
            player.inventory.Remove(slotID);
            Refresh();
        }
        
    }

    public void Swap(int index1, int index2)
    {
        player.inventory.Swap(index1, index2);
        Refresh();
    }


    public void SlotBeginDrag(Slot_UI slot)
    {
        dragSlot = slot;
        dragImage = Instantiate(dragSlot.itemIcon);
        dragImage.transform.SetParent(canvas.transform);
        dragImage.raycastTarget = false;
        dragImage.rectTransform.sizeDelta = new Vector2(50,50);
        FollowMouse(dragImage.gameObject);
        Debug.Log("Start drag: " + dragSlot.name);
    }

    public void SlotDrag()
    {
        FollowMouse(dragImage.gameObject);
        Debug.Log("Dragging: " + dragSlot.name);
    }

    public void SlotEndDrag()
    {
        Debug.Log("End drag: " + dragSlot.name);
        Destroy(dragImage.gameObject);
        dragImage = null;
    }

    public void SlotDrop(Slot_UI slot)
    {
        Debug.Log("Dropped " + dragSlot.name + " on " + slot.name);
        if (dragSlot != null && slot != null && dragSlot != slot)
        {
            Swap(dragSlot.getIndex(), slot.getIndex());
        }
    }

    private void FollowMouse(GameObject obj)
    {
        if(canvas!= null)
        {
            Vector2 position; 
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out position);

            obj.transform.position = canvas.transform.TransformPoint(position);
        }
    }
}
