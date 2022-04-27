using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : Command
{
    public override void Execute(Transform transform, Command command)
    {
        Move(transform);

        InputHandler.instance.oldCommands.Add(command);
    }
    public override void Move(Transform transform)
    {
        transform.Translate(Vector3.forward * moveSpeed);
    }
    public override void Undo(Transform transform)
    {
        transform.Translate(-Vector3.forward * moveSpeed);
    }
}
