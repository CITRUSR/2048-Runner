using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine<PlayerState>, IService
{
    private Dictionary<Type, PlayerState> _states = new Dictionary<Type, PlayerState>();

    public PlayerState GetState<T>() where T : PlayerState
    {
        if (_states.TryGetValue(typeof(T), out PlayerState state))
        {
            return state;
        }

        return null;
    }
}
