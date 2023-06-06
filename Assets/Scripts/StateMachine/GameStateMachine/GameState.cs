using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState : BaseState
{
    public abstract override void Enter();
    public abstract override void Exit();
}
