using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFactory : IPlayerFactory
{
    private Player _prefab;

    public PlayerFactory(Player playerPrefab)
    {
        _prefab = playerPrefab;
    }

    public Player Create(Vector3 pos)
    {
        Player player = Object.Instantiate(_prefab, pos, Quaternion.identity);

        return player;
    }
}
