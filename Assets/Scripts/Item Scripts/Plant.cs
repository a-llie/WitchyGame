using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public CropData asPlant;

    public static void Use()
    {
        Debug.Log("plant from static function");
        GameManager.instance.player.Plant(); 
        
    }

}
