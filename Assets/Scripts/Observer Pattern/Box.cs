using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Observer
{
    GameObject boxObj;
    BoxEvents boxEvent;

    public Box(GameObject boxObj, BoxEvents boxEvent)
    {
        this.boxObj = boxObj;
        this.boxEvent = boxEvent;
    }


    public override void OnNotify()
    {
        Jump(boxEvent.JumpForce());
        Debug.Log("Jumped");
    }

    void Jump(float jumpForce)
    {
        if (boxObj.transform.position.y < 0.55f)
        {
            boxObj.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
        }
    }
}
