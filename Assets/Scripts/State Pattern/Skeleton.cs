using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    EnemyStates skeletonState = EnemyStates.Stroll;
    float health = 100f;

    public Skeleton(Transform skeletonTransform)
    {
        base.enemyTransform = skeletonTransform;
    }

    public override void UpdateEnemy(Transform playerTransform)
    {
        float distance = (base.enemyTransform.position - playerTransform.position).magnitude;

        switch(skeletonState)
        {
            case EnemyStates.Attack:
                if (health < 20f)
                {
                    skeletonState = EnemyStates.Flee;
                }
                else if(distance > 6f)
                {
                    skeletonState = EnemyStates.MoveTowardsPlayer;
                }
                break;
            case EnemyStates.Flee:
                if (health > 60f)
                {
                    skeletonState = EnemyStates.Stroll;
                }
                break;
            case EnemyStates.Stroll:
                if (distance < 10f)
                {
                    skeletonState = EnemyStates.MoveTowardsPlayer;
                }
                break;
            case EnemyStates.MoveTowardsPlayer:
                if (distance < 5.0f)
                {
                    skeletonState = EnemyStates.Attack;
                }
                else if (distance > 15f)
                {
                    skeletonState = EnemyStates.Stroll;
                }
                break;
        }

        DoAction(playerTransform, skeletonState);
    }
}
