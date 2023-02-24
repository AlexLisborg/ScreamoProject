using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public interface IPlayer 
{

    public void ChangeHP(float change);

    public Vector2 getPos();
    public float getDir();

    public float getReach();  
    
    public void setHoldingPostil(bool holding);

    public Vector2 getPlayerHandsPosition();
   
}
