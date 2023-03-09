using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedPacketSprite : MonoBehaviour
{
    
    private Sprite icon; 
    // Start is called before the first frame update
    void Start()
    {   
        icon = GetComponent<Plant>().asPlant.grownVersion;
        Sprite overLayCrop = Instantiate(icon, transform.position, Quaternion.identity);
    }
}
