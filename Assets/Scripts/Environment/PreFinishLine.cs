using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreFinishLine : MonoBehaviour
{
    private EventBus _eventBus;

    private void Start()
    {
        _eventBus = ServiceLocator.Instance.Get<EventBus>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            _eventBus.Invoke(new PreFinishEvent());
        }
    }
}
