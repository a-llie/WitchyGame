using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmWand :  Equipment
{
    public string equipmentName = "FarmWand";
    public override void Use()
    {
        GameManager.instance.player.Plow();
    }
}
