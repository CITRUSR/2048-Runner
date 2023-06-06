using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleMovementState : ForwardMovementState
{
    private PlayerCube _leftCube;
    private PlayerCube _rightCube;
    private PlayerCube _singleCube;

    private Player _player;
    private PlayerStateMachine _playerStateMachine;
    private EventBus _eventBus;

    public SingleMovementState()
    {
        _player = ServiceLocator.Instance.Get<Player>();
        _playerStateMachine = ServiceLocator.Instance.Get<PlayerStateMachine>();
        _eventBus = ServiceLocator.Instance.Get<EventBus>();

        _leftCube = _player.LeftCube;
        _rightCube = _player.RightCube;
        _singleCube = _player.SingleCube;
    }

    public override void Enter()
    {
        base.Enter();
        _eventBus.Subscribe<TouchEvent>(Touch);
    }

    public override void Exit()
    {
        base.Exit();
        _eventBus.Unsubscribe<TouchEvent>(Touch);
    }

    public override void Update()
    {
        base.Update();
    }

    private void Touch(TouchEvent @event)
    {
        _playerStateMachine.SwitchState<DoubleMovementState>();
        _rightCube.SetPower(_singleCube.Power - 1);
        _leftCube.SetPower(_singleCube.Power - 1);
    }
}