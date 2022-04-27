using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SuperPower
{
    public abstract void Activate();

    protected void Move(float speed)
    {
        Debug.Log("Moving with SuperSpeed" + speed);
    }
    protected void PlaySound(string sound)
    {
        Debug.Log("Playing " + sound);
    }
   
}
