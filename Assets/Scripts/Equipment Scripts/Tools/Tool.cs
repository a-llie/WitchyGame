using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    public ToolData toolData;
    //public Equipment equipment;
    
    static Dictionary<string, System.Action> functions = new Dictionary<string, System.Action>();

    void Start()
    {
        functions.Add("FarmWand", FarmWand.Use);
        functions.Add("GarlicPlant", Plant.Use);
        //equipment = GetComponent<Equipment>();
    }


    public static void use(string funcIndex)
    {   
        if(functions.ContainsKey(funcIndex))
            functions[funcIndex]();        
    }


}
