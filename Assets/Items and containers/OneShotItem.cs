using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OneShotItem : ItemScript
{
  
    public override void Activate(IPlayer player)
    {
        base.Activate(player);
        Deactivate(player);
    }
}
