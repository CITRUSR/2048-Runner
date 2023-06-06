using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaitTapState : GameState
{
    private EventBus _eventBus;
    private GameStateMachine _gameStateMachine;
    private GemCounter _gemCounter;
    private GemWindow _gemWindow;
    private TextMeshProUGUI _tapText;

    public WaitTapState(GemWindow gemWindow, TextMeshProUGUI tapText)
    {
        _eventBus = ServiceLocator.Instance.Get<EventBus>();
        _gameStateMachine = ServiceLocator.Instance.Get<GameStateMachine>();
        _gemCounter = ServiceLocator.Instance.Get<GemCounter>();
        _gemWindow = gemWindow;
        _tapText = tapText;
    }

    public override void Enter()
    {
        _eventBus.Subscribe<TouchEvent>(Touch);
        _gemWindow.ShowWindow();
        _tapText.gameObject.SetActive(true);
        _gemWindow.SetGemText(_gemCounter.Gems);
    }

    public override void Exit()
    {
        _eventBus.Unsubscribe<TouchEvent>(Touch);
        _gemWindow.HideWindow();
        _tapText.gameObject.SetActive(false);
    }

    private void Touch(TouchEvent @event)
    {
        _gameStateMachine.SwitchState<GamePlayState>();
    }
}
