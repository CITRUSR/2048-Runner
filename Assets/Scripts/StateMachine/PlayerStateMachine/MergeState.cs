using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeState : ForwardMovementState
{
    private PlayerCube _leftCube;
    private PlayerCube _rightCube;
    private PlayerCube _singleCube;

    private Player _player;
    private PlayerStateMachine _playerStateMachine;
    private EventBus _eventBus;

    private Vector3 _posR;
    private Vector3 _posL;

    public MergeState()
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

        MergeMovement();
        CheckDistance();
    }

    private void MergeMovement()
    {
        _posR = new Vector3(0, _rightCube.transform.position.y, _rightCube.transform.position.z);
        _posL = new Vector3(0, _leftCube.transform.position.y, _leftCube.transform.position.z);

        _leftCube.transform.position = Vector3.MoveTowards(_leftCube.transform.position, _posR, _player.Parameters.MergeSpeed * Time.deltaTime);
        _rightCube.transform.position = Vector3.MoveTowards(_rightCube.transform.position, _posL, _player.Parameters.MergeSpeed * Time.deltaTime);
    }

    private void CheckDistance()
    {
        if (Vector3.Distance(_leftCube.transform.position, _rightCube.transform.position) <= 2.2)
        {
            EnableKinematic();
            if (Vector3.Distance(_leftCube.transform.position, _rightCube.transform.position) <= 0.5)
            {
                _singleCube.gameObject.SetActive(true);
                _leftCube.gameObject.SetActive(false);
                _rightCube.gameObject.SetActive(false);

                if (_leftCube.Power == _rightCube.Power)
                {
                    _singleCube.SetPower(_leftCube.Power + 1);
                }
                else if (_leftCube.Power > _rightCube.Power)
                    _singleCube.SetPower(_rightCube.Power);

                _playerStateMachine.SwitchState<SingleMovementState>();
            }
        }
    }

    private void Touch(TouchEvent @event)
    {
        _playerStateMachine.SwitchState<DoubleMovementState>();
    }

    private void EnableKinematic()
    {
        _leftCube.EnableKinematic();
        _rightCube.EnableKinematic();
    }
}
