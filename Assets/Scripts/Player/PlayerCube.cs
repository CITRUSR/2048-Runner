using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(Rigidbody))]
public class PlayerCube : BaseCube
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private CubeAnimator _animator;
    private EventBus _eventBus;
    private PlayerStateMachine _playerStateMachine;
    private GameStateMachine _gameStateMachine;

    private void Start()
    {
        CubeRefresh();
        _eventBus = ServiceLocator.Instance.Get<EventBus>();
        _playerStateMachine = ServiceLocator.Instance.Get<PlayerStateMachine>();
        _gameStateMachine = ServiceLocator.Instance.Get<GameStateMachine>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<OtherCube>(out OtherCube cube) && Power == cube.Power)
        {
            if (IsActive)
            {
                UpPower(1);
                Destroy(cube.gameObject);
            }
        }
    }

    public override void DownPower(int PowerLevel)
    {
        Power -= PowerLevel;

        if (Power > 0)
        {
            CubeRefresh();
            _animator.PlaySizeAnimation();

            if (_playerStateMachine.CurrentState == _playerStateMachine.GetState<SingleMovementState>())
            {
                _eventBus.Invoke(new PowerDownEvent(Power));
            }
            else
            {
                _eventBus.Invoke(new PowerDownEvent(Power - 1));
            }
        }
        else
        {
            _gameStateMachine.SwitchState<LoseState>();
            Destroy(gameObject);
        }
    }

    public override void SetPower(ECubePower power)
    {
        base.SetPower(power);
        _animator.PlaySizeAnimation();
    }

    public override void UpPower(int PowerLevel)
    {
        base.UpPower(PowerLevel);

        if (_playerStateMachine.CurrentState == _playerStateMachine.GetState<SingleMovementState>())
        {
            _eventBus.Invoke(new PowerUpEvent(Power));
        }
        else
        {
            _eventBus.Invoke(new PowerUpEvent(Power + 1));
        }

        _animator.PlaySizeAnimation();
    }

    public void EnableKinematic()
    {
        _rb.isKinematic = true;
        IsActive = false;
    }

    public void DisableKinematic()
    {
        _rb.isKinematic = false;
        IsActive = true;
    }
}
