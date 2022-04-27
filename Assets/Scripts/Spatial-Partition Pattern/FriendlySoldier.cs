using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlySoldier : Soldier
{
    public FriendlySoldier(GameObject soldierObj, float mapWidth)
    {
        this.soldierTransform = soldierObj.transform;

        this.walkSpeed = 2f;
    }


    //Move towards the closest enemy - will always move within its grid
    public override void Move(Soldier closestEnemy)
    {
    
        soldierTransform.rotation = Quaternion.LookRotation(closestEnemy.soldierTransform.position - soldierTransform.position);
      
        soldierTransform.Translate(Vector3.forward * Time.deltaTime * walkSpeed);
    }
}
