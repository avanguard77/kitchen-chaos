using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounter : BaseCounter
{
    public override void interact(Player player)
    {
        if (player.hasKitchenObject())
        {
            player.getKitchenObject().destroySelf();
        }
    }
}
