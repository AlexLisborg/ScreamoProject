using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : ItemScript
{
    public override Activation getActivation()
    {
        throw new System.NotImplementedException();
    }

    public override Sprite getIcon()
    {
        throw new System.NotImplementedException();
    }

    public class BulletActivation : Activation
    {
        public void Activate(IPlayer player, GameObject go)
        {
            throw new System.NotImplementedException();
        }

        public void Deactivate(IPlayer player, GameObject go)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateActivation(IPlayer player, GameObject go)
        {
            throw new System.NotImplementedException();
        }
    }
}
