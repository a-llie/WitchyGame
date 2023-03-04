using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tool Data", menuName = "Tool Data", order = 50)]
public class ToolData : ScriptableObject
{
    public ItemData itemData;
    public string toolName;
    public GameObject toolScript;

    void Start()
    {
        toolName = itemData.itemName;
    }
}
