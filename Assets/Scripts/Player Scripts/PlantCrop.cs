using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantCrop : MonoBehaviour
{
    bool planting = false;

    public GameObject crop; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (planting)
        {
            if (Input.GetButtonDown("Fire1")){
                    GameObject plant = Instantiate(crop, transform.position, transform.rotation );
            } 
        }
    }
}