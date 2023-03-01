using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Slot_UI : MonoBehaviour
{
    // Start is called before the first frame update
    public Image itemIcon;
    public TextMeshProUGUI quantityText; 
    [SerializeField] private GameObject hightlight;

    public void SetItem(Inventory.Slot slot)
    {
        if(slot != null)
        { 
            itemIcon.sprite = slot.icon;
            itemIcon.color = new Color(1,1,1,1);
            quantityText.text = slot.count.ToString();
        }
    }


    public void SetEmpty()
    {
        itemIcon.sprite = null; 
        itemIcon.color = new Color(1,1,1,1); 
        quantityText.text = "0";
    }


    public void SetHighlight()
    {
        hightlight.SetActive(!hightlight.activeSelf);
    }
    
    public void SetButtonOnClick(int index)
    {
        transform.GetChild(2).gameObject.GetComponent<InvRemoveButton>().SetIndex(index);
    }
}
