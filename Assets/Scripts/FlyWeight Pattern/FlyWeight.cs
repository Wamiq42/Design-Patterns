using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyWeight : MonoBehaviour
{
    List<Alien> totalAliens = new List<Alien>();

    List<Vector3> eyePositions;
    List<Vector3> legPositions;
    List<Vector3> armPositions;

    private void Start()
    {
        eyePositions = GetBodyParts();
        legPositions = GetBodyParts();
        armPositions = GetBodyParts();
        for (int i = 0; i < 10000; i++)
        {
            Alien newAlien = new Alien();
            //newAlien.eyePositions = GetBodyParts();
            //newAlien.legPositions = GetBodyParts();
            //newAlien.armPositions = GetBodyParts();

            newAlien.eyePositions = this.eyePositions;
            newAlien.legPositions = this.legPositions;
            newAlien.armPositions = this.armPositions;

            totalAliens.Add(newAlien);
        }
    }

    List<Vector3> GetBodyParts()
    {
        List<Vector3> bodyParts = new List<Vector3>();

        for (int i = 0; i < 1000; i++)
        {
            bodyParts.Add(new Vector3());
        }

        return bodyParts;
    }
}
