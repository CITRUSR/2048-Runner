using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleMovementState : ForwardMovementState
{
    private PlayerCube _leftCube;
    private PlayerCube _rightCube;
    private PlayerCube _singleCube;

    private Player _player;
    private PlayerStateMachine _playerStateMachine;
    private EventBus _eventBus;

    private Vector3 _posR;
    private Vector3 _posL;

    public DoubleMovementState()
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

        _singleCube.gameObject.SetActive(false);
        _rightCube.gameObject.SetActive(true);
        _leftCube.gameObject.SetActive(true);
    }

    public override void Exit()
    {
        base.Exit();
        _eventBus.Unsubscribe<TouchEvent>(Touch);
    }

    public override void Update()
    {
        base.Update();

        _posL = new Vector3(_player.transform.position.x - 2, _leftCube.transform.position.y, _leftCube.transform.position.z);
        _posR = new Vector3(_player.transform.position.x + 2, _rightCube.transform.position.y, _rightCube.transform.position.z);

        _leftCube.transform.position = Vector3.MoveTowards(_leftCube.transform.position, _posL, _player.Parameters.MergeSpeed * Time.deltaTime);
        _rightCube.transform.position = Vector3.MoveTowards(_rightCube.transform.position, _posR, _player.Parameters.MergeSpeed * Time.deltaTime);

        if (Vector3.Distance(_leftCube.transform.position, _rightCube.transform.position) >= 2)
        {
            DisableKinematic();
        }
    }

    private void Touch(TouchEvent @event)
    {
        _playerStateMachine.SwitchState<MergeState>();
    }

    private void DisableKinematic()
    {
        _leftCube.DisableKinematic();
        _rightCube.DisableKinematic();
    }
}