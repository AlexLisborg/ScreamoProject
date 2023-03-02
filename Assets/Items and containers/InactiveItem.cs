using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InactiveItem : ItemScript
{
    public override Activation getActivation()
    {
        return new Inactive();
    }

    public class Inactive : Activation
    {
       
    }



}
