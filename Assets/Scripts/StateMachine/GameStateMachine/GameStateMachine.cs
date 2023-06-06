using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameStateMachine : StateMachine<GameState>, IService
{
    private Dictionary<Type, GameState> _states = new Dictionary<Type, GameState>();

}