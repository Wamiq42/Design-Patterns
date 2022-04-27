using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperLaunch : SuperPower
{
    public override void Activate()
    {
        Move(10f);
        PlaySound("Launch Sound");
    }
   
}
