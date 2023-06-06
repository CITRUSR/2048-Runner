using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : BaseState
{
    public abstract override void Enter();
    public abstract override void Update();
    public abstract override void Exit();
}
