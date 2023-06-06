using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T> where T : BaseState
{
    public T CurrentState { get; private set; }

    private Dictionary<Type, T> _states = new Dictionary<Type, T>();

    public virtual void AddState(T state)
    {
        _states.Add(state.GetType(), state);
    }

    public virtual void SwitchState<TY>() where TY : T
    {
        if (_states.TryGetValue(typeof(TY), out T newstate))
        {
            CurrentState?.Exit();
            CurrentState = newstate;
            CurrentState.Enter();
        }
    }
}
