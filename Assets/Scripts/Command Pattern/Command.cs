using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    protected float moveSpeed = 1.0f;

    public abstract void Execute(Transform transform, Command command);

    public virtual void Move(Transform transform) { }
    public virtual void Undo(Transform transform) { }
}
