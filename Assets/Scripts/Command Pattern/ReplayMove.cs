using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayMove : Command
{
    public override void Execute(Transform transform, Command command)
    {
        InputHandler.instance.startReplay = true;
    }
}
