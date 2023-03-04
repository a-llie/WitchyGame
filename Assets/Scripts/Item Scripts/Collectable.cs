using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Item))]
public class Collectable : MonoBehaviour
{
    public bool isCollectable; 


    public Collectable(bool isCollect=true)
    {
        isCollectable = isCollect;
    }

    public void Start()
    {
        isCollectable = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        Toolbar_UI toolbar = GameManager.instance.GetComponent<Toolbar_UI>();

        if(player && isCollectable){
            Item item = GetComponent<Item>();
            if (item != null)
            {
                player.inventory.Add(item);
                toolbar.Refresh();
                Destroy(this.gameObject);
            }
            
        }
    }


}

