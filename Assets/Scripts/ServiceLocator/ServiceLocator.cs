using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator
{
    private Dictionary<Type, IService> _services = new Dictionary<Type, IService>();

    public static ServiceLocator Instance { get; private set; }

    public static void InitServiceLocator()
    {
        Instance = new ServiceLocator();
    }

    public void AddService<T>(T service) where T : IService
    {
        var type = typeof(T);

        if (_services.ContainsKey(type))
        {
            return;
        }

        _services.Add(type, service);
    }

    public void RemoveService<T>(T service) where T : IService
    {
        var type = typeof(T);

        if (!_services.ContainsKey(type))
        {
            return;
        }

        _services.Remove(type);
    }

    public T Get<T>() where T : IService
    {
        var type = typeof(T);

        if (!_services.ContainsKey(type))
        {
            throw new InvalidOperationException();
        }

        return (T)_services[type];
    }
}
