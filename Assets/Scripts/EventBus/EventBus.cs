using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EventBus : IService
{
    private Dictionary<Type, List<object>> _eventsCallback = new Dictionary<Type, List<object>>();

    public void Subscribe<T>(Action<T> callback)
    {
        var type = typeof(T);
        if (_eventsCallback.ContainsKey(type))
        {
            _eventsCallback[type].Add(callback);
        }
        else
        {
            _eventsCallback.Add(type, new List<object>() { callback });
        }
    }

    public void Unsubscribe<T>(Action<T> callback)
    {
        var type = typeof(T);
        if (_eventsCallback.ContainsKey(type))
        {
            _eventsCallback[type].Remove(callback);
        }
    }

    public void Invoke<T>(T @event)
    {
        var type = typeof(T);
        if (_eventsCallback.ContainsKey(type))
        {
            foreach (var obj in _eventsCallback[type].ToList())
            {
                var Callback = obj as Action<T>;
                Callback?.Invoke(@event);
            }
        }
    }
}
