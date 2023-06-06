using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayState : GameState
{
    private PlayerStateMachine _playerStateMachine;
    private GameStateMachine _gameStateMachine;
    private EventBus _eventBus;
    private RestartButton _restartButton;

    public GamePlayState(RestartButton restartButton)
    {
        _playerStateMachine = ServiceLocator.Instance.Get<PlayerStateMachine>();
        _gameStateMachine = ServiceLocator.Instance.Get<GameStateMachine>();
        _eventBus = ServiceLocator.Instance.Get<EventBus>();
        _restartButton = restartButton;
    }

    public override void Enter()
    {
        _playerStateMachine.SwitchState<SingleMovementState>();
        _eventBus.Subscribe<PreFinishEvent>(PreFinish);
        _restartButton.gameObject.SetActive(true);
    }

    public override void Exit()
    {
        _eventBus.Unsubscribe<PreFinishEvent>(PreFinish);
        _restartButton.gameObject.SetActive(false);
    }

    private void PreFinish(PreFinishEvent @event)
    {
        _gameStateMachine.SwitchState<PreFinishState>();
    }
}
