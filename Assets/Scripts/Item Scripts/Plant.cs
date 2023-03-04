using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public CropData cropData;

    public static void Use()
    {
        GameManager.instance.tileManager.cropMap.SetTile(new Vector3Int(0,0,0) ,GameManager.instance.tileManager.garlicTile);
        
    }

}
