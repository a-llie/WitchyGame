using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    //public Equipment equipment;
    
    static Dictionary<string, System.Action> functions = new Dictionary<string, System.Action>();

    void Start()
    {
        functions.Add("FarmWand", FarmWand.Use);
        functions.Add("GarlicSeeds", Plant.Use);
        //equipment = GetComponent<Equipment>();
    }


    public static void use(string funcIndex)
    {   
        Debug.Log("in functions script");
        if(functions.ContainsKey(funcIndex))
            functions[funcIndex]();        
    }


}
