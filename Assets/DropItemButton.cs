using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemButton : MonoBehaviour
{
    // Start is called before the first frame update
    public int index;

    public void CallRemove()
    {
        GameObject.Find("Player").GetComponent<Player>().inventory.Remove(index);
    }
    

}
