using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmWand :  MonoBehaviour
{
    public static void Use()
    {
        Debug.Log("in farm wand script");
        GameManager.instance.player.Plow();
    }
}
