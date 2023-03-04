using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmWand :  MonoBehaviour
{
    public static void Use()
    {
        GameManager.instance.player.Plow();
    }
}
