using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : GameState
{
    private PlayerStateMachine _playerStateMachine;
    private WinWindow _finishWindow;
    private Level _completedLevel;
    private GemCounter _gemCounter;
    private ISaver _saver;

    public WinState(WinWindow finishWindow)
    {
        _finishWindow = finishWindow;
        _playerStateMachine = ServiceLocator.Instance.Get<PlayerStateMachine>();
        _completedLevel = ServiceLocator.Instance.Get<Level>();
        _gemCounter = ServiceLocator.Instance.Get<GemCounter>();
        _saver = ServiceLocator.Instance.Get<ISaver>();
    }

    public override void Enter()
    {
        _finishWindow.ShowWindow();
        _finishWindow.Init();
        _playerStateMachine.SwitchState<IdleState>();
        _gemCounter.AddGem(_completedLevel.GemPerLevel);
        Save();
    }

    public override void Exit()
    {
        _finishWindow.HideWindow();
    }

    private void Save()
    {
        GameData newData = new GameData();
        newData.Gems = _gemCounter.Gems;
        _saver.Save(newData);
    }
}
