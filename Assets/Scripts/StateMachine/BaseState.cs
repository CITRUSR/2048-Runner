using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }
}
