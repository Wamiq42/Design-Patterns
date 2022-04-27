using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerSpatialPartition : MonoBehaviour
{
    public GameObject friendlyObject;
    public GameObject enemyObject;

    public Material enemyMaterial;
    public Material closestEnemyMaterial;

    public Transform enemyParent;
    public Transform friendlyParent;

    List<Soldier> enemySoldiers = new List<Soldier>();
    List<Soldier> friendlySoldiers = new List<Soldier>();

    List<Soldier> closestEnemies = new List<Soldier>();

    float mapWidth = 50f;
    int cellSize = 10;

    int numberOfSoldiers = 50;

    Grid grid;

    private void Start()
    {
        grid = new Grid((int)mapWidth, cellSize);

        
        for (int i = 0; i < numberOfSoldiers; i++)
        {
         
            Vector3 randomPos = new Vector3(Random.Range(0f, mapWidth), 0.5f, Random.Range(0f, mapWidth));

           
            GameObject newEnemy = Instantiate(enemyObject, randomPos, Quaternion.identity) as GameObject;

            enemySoldiers.Add(new EnemySoldier(newEnemy, mapWidth, grid));

            
            newEnemy.transform.parent = enemyParent;


           //Adding Friendly Soldiers;
            randomPos = new Vector3(Random.Range(0f, mapWidth), 0.5f, Random.Range(0f, mapWidth));

           
            GameObject newFriendly = Instantiate(friendlyObject, randomPos, Quaternion.identity) as GameObject;

           
            friendlySoldiers.Add(new FriendlySoldier(newFriendly, mapWidth));

            
            newFriendly.transform.parent = friendlyParent;
        }
    }
    void Update()
    {
       
        for (int i = 0; i < enemySoldiers.Count; i++)
        {
            enemySoldiers[i].Move();
        }

      
        for (int i = 0; i < closestEnemies.Count; i++)
        {
            closestEnemies[i].soldierMeshRenderer.material = enemyMaterial;
        }

     
        closestEnemies.Clear();

        
        for (int i = 0; i < friendlySoldiers.Count; i++)
        {
            //Soldier closestEnemy = FindClosestEnemySlow(friendlySoldiers[i]);

            //The fast version with spatial partition
            Soldier closestEnemy = grid.FindClosestEnemy(friendlySoldiers[i]);

            //If we found an enemy
            if (closestEnemy != null)
            {
                //Change material
                closestEnemy.soldierMeshRenderer.material = closestEnemyMaterial;

                closestEnemies.Add(closestEnemy);

                //Move the friendly in the direction of the enemy
                friendlySoldiers[i].Move(closestEnemy);
            }
        }
    }
    //Find the closest enemy - slow version
    Soldier FindClosestEnemySlow(Soldier soldier)
    {
        Soldier closestEnemy = null;

        float bestDistSqr = Mathf.Infinity;

        //Loop thorugh all enemies
        for (int i = 0; i < enemySoldiers.Count; i++)
        {
            
            float distSqr = (soldier.soldierTransform.position - enemySoldiers[i].soldierTransform.position).sqrMagnitude;

       
            if (distSqr < bestDistSqr)
            {
                bestDistSqr = distSqr;

                closestEnemy = enemySoldiers[i];
            }
        }

        return closestEnemy;
    }
}


