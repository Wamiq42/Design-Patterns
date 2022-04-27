using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoldier : Soldier
{
    Vector3 currentTarget;
    Vector3 oldPos;
    float mapWidth;

    Grid grid;

    public EnemySoldier (GameObject soldierObj, float mapWidth, Grid grid)
    {
        this.soldierTransform = soldierObj.transform;
        this.soldierMeshRenderer = soldierObj.GetComponent<MeshRenderer>();
        this.mapWidth = mapWidth;
        this.grid = grid;

        grid.Add(this);

        oldPos = soldierTransform.position;

        this.walkSpeed = 5.0f;
        
        GetNewTarget();
    }
    public override void Move()
    {
        soldierTransform.Translate(Vector3.forward * Time.deltaTime * walkSpeed);

       
        grid.Move(this, oldPos);

     
        oldPos = soldierTransform.position;

       
        if ((soldierTransform.position - currentTarget).magnitude < 1f)
        {
            GetNewTarget();
        }
    }
    private void GetNewTarget()
    {
        currentTarget = new Vector3(Random.Range(0f,mapWidth),0, Random.Range(0f, mapWidth));

        //Rotate towards the target
        soldierTransform.rotation = Quaternion.LookRotation(currentTarget - soldierTransform.position);
    }
}
