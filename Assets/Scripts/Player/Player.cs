using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IService
{
    public ECubePower Power;
    public PlayerParameters Parameters;

    public PlayerCube LeftCube;
    public PlayerCube RightCube;
    public PlayerCube SingleCube;

    private PlayerStateMachine _stateMachine;
    private EventBus _eventBus;

    private void OnDisable()
    {
        _eventBus.Unsubscribe<PowerUpEvent>(PowerUp);
    }

    private void Start()
    {
        _stateMachine = ServiceLocator.Instance.Get<PlayerStateMachine>();
        _eventBus = ServiceLocator.Instance.Get<EventBus>();

        _eventBus.Subscribe<PowerUpEvent>(PowerUp);

        SingleCube.Power = Power;
        LeftCube.Power = Power - 1;
        RightCube.Power = Power - 1;

        _stateMachine.SwitchState<IdleState>();
    }

    private void Update()
    {
        if (_stateMachine.CurrentState != null)
            _stateMachine.CurrentState.Update();
    }

    private void PowerUp(PowerUpEvent @event)
    {
        Power = @event.Power;
    }
}
