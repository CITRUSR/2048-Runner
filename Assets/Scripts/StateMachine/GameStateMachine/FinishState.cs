using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishState : GameState
{
    private PlayerStateMachine _playerStateMachine;
    private Player _player;
    private GameStateMachine _gameStateMachine;
    private IInput _input;
    private IStarCalculator _starCalculator;
    private Level _level;

    public FinishState()
    {
        _playerStateMachine = ServiceLocator.Instance.Get<PlayerStateMachine>();
        _player = ServiceLocator.Instance.Get<Player>();
        _gameStateMachine = ServiceLocator.Instance.Get<GameStateMachine>();
        _input = ServiceLocator.Instance.Get<IInput>();
        _starCalculator = ServiceLocator.Instance.Get<IStarCalculator>();
        _level = ServiceLocator.Instance.Get<Level>();
    }

    public override void Enter()
    {
        _playerStateMachine.SwitchState<IdleState>();

        if (_starCalculator.CalculateStarCount(_player.Power, _level) != 0)
        {
            _gameStateMachine.SwitchState<WinState>();
        }
        else
        {
            _gameStateMachine.SwitchState<LoseState>();
        }
    }

    public override void Exit()
    {
        _input.EnableInput();
    }
}
