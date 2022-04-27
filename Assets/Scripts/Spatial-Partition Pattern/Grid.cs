using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    int cellSize;

    Soldier[,] cells;

    public Grid(int mapWidth, int cellSize)
    {
        this.cellSize = cellSize;
        int numberOfCells = mapWidth / cellSize;
        cells = new Soldier[numberOfCells, numberOfCells];
    }

    public void Add(Soldier soldier)
    {
        int cellX = (int)(soldier.soldierTransform.position.x / cellSize);
        int cellZ = (int)(soldier.soldierTransform.position.z / cellSize);

        soldier.previousSoldier = null;
        soldier.nextSoldier = cells[cellX, cellZ];

        cells[cellX, cellZ] = soldier;

        if (soldier.nextSoldier != null)
        {
            soldier.nextSoldier.previousSoldier = soldier;
        }
    }

    public Soldier FindClosestEnemy(Soldier friendlySoldier)
    {
        int cellX = (int)(friendlySoldier.soldierTransform.position.x / cellSize);
        int cellZ = (int)(friendlySoldier.soldierTransform.position.x / cellSize);

        Soldier enemy = cells[cellX, cellZ];

        Soldier closestSoldier = null;

        float bestDistSqr = Mathf.Infinity;

        while (enemy != null)
        {
            float distSqr = (enemy.soldierTransform.position - friendlySoldier.soldierTransform.position).magnitude;
            
            if(distSqr < bestDistSqr)
            {
                bestDistSqr = distSqr;
                closestSoldier = enemy;
            }

            enemy = enemy.nextSoldier;
        }

        return closestSoldier;
    }

    public void Move(Soldier soldier ,Vector3 oldPos)
    {
        int oldCellX = (int)(oldPos.x / cellSize);
        int oldCellZ = (int)(oldPos.z / cellSize);

        int cellX = (int)(soldier.soldierTransform.position.x / cellSize);
        int cellZ = (int)(soldier.soldierTransform.position.z / cellSize);

        if (oldCellX == cellX && oldCellZ == cellZ)
        {
            return;
        }

        
        if (soldier.previousSoldier != null)
        {
            soldier.previousSoldier.nextSoldier = soldier.nextSoldier;
        }

        if (soldier.nextSoldier != null)
        {
            soldier.nextSoldier.previousSoldier = soldier.previousSoldier;
        }

       
        if (cells[oldCellX, oldCellZ] == soldier)
        {
            cells[oldCellX, oldCellZ] = soldier.nextSoldier;
        }

        Add(soldier);
    }

}
