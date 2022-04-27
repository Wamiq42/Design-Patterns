using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creeper : Enemy
{
    EnemyStates creeperMode = EnemyStates.Stroll;
    float health = 100f;

    public Creeper(Transform creepreTransform)
    {
        base.enemyTransform = creepreTransform;
    }
    public override void UpdateEnemy(Transform playerTransform)
    {
        float distance = (base.enemyTransform.position - playerTransform.position).magnitude;
        
        switch (creeperMode)
        {
            case EnemyStates.Attack:
                if (health < 20f)
                {
                    creeperMode = EnemyStates.Flee;
                }
                else if (distance > 2f)
                {
                    creeperMode = EnemyStates.MoveTowardsPlayer;
                }
                break;
            case EnemyStates.Flee:
                if (health > 60f)
                {
                    creeperMode = EnemyStates.Stroll;
                }
                break;
            case EnemyStates.Stroll:
                if (distance < 10f)
                {
                    creeperMode = EnemyStates.MoveTowardsPlayer;
                }
                break;
            case EnemyStates.MoveTowardsPlayer:
                if (distance < 1f)
                {
                    creeperMode = EnemyStates.Attack;
                }
                else if (distance > 15f)
                {
                    creeperMode = EnemyStates.Stroll;
                }
                break;
        }

        //Move the enemy based on a state
        DoAction(playerTransform, creeperMode);
    }
}

