using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    protected Transform enemyTransform;

    protected enum EnemyStates { Attack, Flee, Stroll, MoveTowardsPlayer }

    public virtual void UpdateEnemy(Transform playerTransform)
    {

    }
    protected void DoAction(Transform playerTransform, EnemyStates enemyState)
    {
        float fleeSpeed = 10.0f;
        float strollSpeed = 1.0f;
        float attackSpeed = 5.0f;
        
        switch(enemyState)
        {
            case EnemyStates.Attack:
                //Attack player
                Debug.Log("Attack Player");
                break;
            case EnemyStates.Flee:
                enemyTransform.rotation = Quaternion.LookRotation(enemyTransform.position - playerTransform.position);
                enemyTransform.Translate(enemyTransform.forward * fleeSpeed * Time.deltaTime);
                break;
            case EnemyStates.Stroll:
                Vector3 randomPos = new Vector3(Random.Range(0f, 100f), 0f, Random.Range(0f, 100f));
                enemyTransform.rotation = Quaternion.LookRotation(enemyTransform.position - randomPos);
                enemyTransform.Translate(enemyTransform.forward * strollSpeed * Time.deltaTime);
                break;
            case EnemyStates.MoveTowardsPlayer:
                enemyTransform.rotation = Quaternion.LookRotation(playerTransform.position - enemyTransform.position);
                enemyTransform.Translate(enemyTransform.forward * attackSpeed * Time.deltaTime);
                break;
        }
    }
}
