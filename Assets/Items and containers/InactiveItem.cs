using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InactiveItem : ItemScript
{
    public override Activation getActivation()
    {
        throw new System.NotImplementedException();
    }

    public class Inactive : Activation
    {
        public void Activate(IPlayer player, GameObject go)
        {

        }

        public void Deactivate(IPlayer player, GameObject go)
        {
        }

        public void UpdateActivation(IPlayer player, GameObject go)
        {
        }
    }

}
