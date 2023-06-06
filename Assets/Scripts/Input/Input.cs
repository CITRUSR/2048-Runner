using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Input : IInput
{
    private Button _touchButton;
    private EventBus _eventBus;

    public Input(Button touchButton)
    {
        _touchButton = touchButton;
        _eventBus = ServiceLocator.Instance.Get<EventBus>();
        _touchButton.onClick.AddListener(Touch);
    }

    public void Touch()
    {
        _eventBus.Invoke(new TouchEvent());
    }

    public void DisableInput()
    {
        _touchButton.gameObject.SetActive(false);
    }

    public void EnableInput()
    {
        _touchButton.gameObject.SetActive(true);
    }
}