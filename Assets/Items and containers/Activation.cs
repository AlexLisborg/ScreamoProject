using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Activation
{
    public void Activate(IPlayer player, GameObject go);

    public void UpdateActivation(IPlayer player, GameObject go);

    public void Deactivate(IPlayer player, GameObject go);
}
