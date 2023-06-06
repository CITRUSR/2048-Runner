using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMovementState : PlayerState
{
    private Player _player;

    public ForwardMovementState()
    {
        _player = ServiceLocator.Instance.Get<Player>();
    }

    public override void Enter()
    {

    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        Movement();
    }

    protected void Movement()
    {
        _player.transform.Translate(Vector3.forward * _player.Parameters.Speed * Time.deltaTime);
    }
}
