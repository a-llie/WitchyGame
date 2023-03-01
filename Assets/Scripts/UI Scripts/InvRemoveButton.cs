using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvRemoveButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       Debug.Log("setting up button");
    }

    public void SetIndex(int index)
    {
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => {
            GameManager.instance.inventoryUI.Remove(index);
       });
    }
}
