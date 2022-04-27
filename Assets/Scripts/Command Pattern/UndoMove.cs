using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoMove : Command
{
    public override void Execute(Transform transform, Command command)
    {
        List<Command> oldCommands = InputHandler.instance.oldCommands;

        if(oldCommands.Count > 0)
        {
            Command latestCommand = oldCommands[oldCommands.Count - 1];

            latestCommand.Undo(transform);

            oldCommands.RemoveAt(oldCommands.Count - 1);
        }
    }
}
