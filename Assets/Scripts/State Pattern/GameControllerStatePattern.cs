using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerStatePattern : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject creeperObject;
    public GameObject skeletonObject;

    List<Enemy> enemies = new List<Enemy>();

    void Start()
    {
        enemies.Add(new Creeper(creeperObject.transform));
        enemies.Add(new Skeleton(skeletonObject.transform));
    }

    private void Update()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].UpdateEnemy(playerObject.transform);
        }
    }
}
