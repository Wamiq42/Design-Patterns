using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperheroLanding : SuperPower
{
    public override void Activate()
    {

        Move(10 * -9.8f);
        PlaySound("*Ground Shaking Sound*");
        
    }
}
