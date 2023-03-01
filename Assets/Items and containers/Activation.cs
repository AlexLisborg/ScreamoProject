using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation
{
    public virtual void Activate(IPlayer player, GameObject go) { }

    public virtual void UpdateActivation(IPlayer player, GameObject go) { }

    public virtual void Deactivate(IPlayer player, GameObject go) { }

    public virtual void Equipt(IPlayer player, GameObject go) { }

    public virtual void UpdateEquiptment(IPlayer player, GameObject go) { }

    public virtual void Unequipt(IPlayer player, GameObject go) { }
}
