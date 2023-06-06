using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseState : GameState
{
    private PlayerStateMachine _playerStateMachine;
    private LoseWindow _loseWindow;

    public LoseState(LoseWindow loseWindow)
    {
        _playerStateMachine = ServiceLocator.Instance.Get<PlayerStateMachine>();
        _loseWindow = loseWindow;
    }

    public override void Enter()
    {
        _loseWindow.ShowWindow();
        _playerStateMachine.SwitchState<IdleState>();
    }

    public override void Exit()
    {
        _loseWindow.HideWindow();
    }
}
