using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreFinishState : GameState
{
    private EventBus _eventBus;
    private GameStateMachine _gameStateMachine;
    private PlayerStateMachine _playerStateMachine;
    private IInput _input;

    public PreFinishState()
    {
        _eventBus = ServiceLocator.Instance.Get<EventBus>();
        _gameStateMachine = ServiceLocator.Instance.Get<GameStateMachine>();
        _playerStateMachine = ServiceLocator.Instance.Get<PlayerStateMachine>();
        _input = ServiceLocator.Instance.Get<IInput>();
    }


    public override void Enter()
    {
        _playerStateMachine.SwitchState<MergeState>();
        _input.DisableInput();
        _eventBus.Subscribe<FinishEvent>(Finish);
    }

    public override void Exit()
    {
        _eventBus.Unsubscribe<FinishEvent>(Finish);
    }

    private void Finish(FinishEvent @event)
    {
        _gameStateMachine.SwitchState<FinishState>();
    }
}