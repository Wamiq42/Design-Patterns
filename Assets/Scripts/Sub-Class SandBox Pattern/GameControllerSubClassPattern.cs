using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerSubClassPattern : MonoBehaviour
{
    List<SuperPower> superPowers = new List<SuperPower>();

    private void Start()
    {
        superPowers.Add(new SuperLaunch());
        superPowers.Add(new SuperheroLanding());
    }
    private void Update()
    {
        for (int i = 0; i < superPowers.Count; i++)
        {
            superPowers[i].Activate();
        }
    }
}
