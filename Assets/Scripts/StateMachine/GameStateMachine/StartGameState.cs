using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class StartGameState : GameState
{
    private GameStateMachine _gameStateMachine;
    private ILevelFactory _levelFactory;
    private IPlayerFactory _playerFactory;
    private ILoader _loader;
    private GemCounter _gemCounter;
    private CinemachineVirtualCamera _camera;

    public StartGameState(CinemachineVirtualCamera camera)
    {
        _gameStateMachine = ServiceLocator.Instance.Get<GameStateMachine>();
        _levelFactory = ServiceLocator.Instance.Get<ILevelFactory>();
        _playerFactory = ServiceLocator.Instance.Get<IPlayerFactory>();
        _loader = ServiceLocator.Instance.Get<ILoader>();
        _gemCounter = ServiceLocator.Instance.Get<GemCounter>();

        _camera = camera;
    }

    public override void Enter()
    {
        Level level = _levelFactory.Create(0);
        Player player = _playerFactory.Create(new Vector3(0, 1, 0));

        ServiceLocator.Instance.AddService<Player>(player);
        ServiceLocator.Instance.AddService<Level>(level);

        _camera.Follow = player.transform;
        _camera.LookAt = player.transform;

        Load();

        _gameStateMachine.SwitchState<WaitTapState>();
    }

    public override void Exit()
    {

    }

    private void Load()
    {
        GameData loadData = (GameData)_loader.Load<GameData>();
        _gemCounter.SetGem(loadData.Gems);
    }
}
