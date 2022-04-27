using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject sphereObj;
    
    public GameObject[] boxes;

    Subject subject = new Subject();

    private void Start()
    {
        Box box1 = new Box(boxes[0], new JumpLittle());
        Box box2 = new Box(boxes[1], new JumpMedium());
        Box box3 = new Box(boxes[2], new JumpHigh());

        subject.AddObserver(box1);
        subject.AddObserver(box2);
        subject.AddObserver(box3);
    }

    private void Update()
    {
        if ((sphereObj.transform.position).magnitude < 0.5f)
        {
            subject.Notify();
        }
    }
}
