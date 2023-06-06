using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinWindow : Window
{
    [SerializeField] private StarUI[] _stars;

    private Player _player;
    private Level _level;
    private IStarCalculator _starCalculator;

    public void Init()
    {
        _player = ServiceLocator.Instance.Get<Player>();
        _level = ServiceLocator.Instance.Get<Level>();
        _starCalculator = ServiceLocator.Instance.Get<IStarCalculator>();

        for (int i = 0; i < _starCalculator.CalculateStarCount(_player.Power, _level); i++)
        {
            _stars[i].ActiveStar();
        }
    }
}
