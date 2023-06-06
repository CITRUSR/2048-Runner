using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLevelFactory : ILevelFactory
{
    private LevelsConfig _levelsConfig;

    public RandomLevelFactory(LevelsConfig levelsConfig)
    {
        _levelsConfig = levelsConfig;
    }

    public Level Create(int id)
    {
        if (_levelsConfig.Levels.Length <= id)
            return null;

        var level = Object.Instantiate(_levelsConfig.Levels[Random.Range(0, _levelsConfig.Levels.Length)]);
        level.transform.position = Vector3.zero;

        return level;
    }
}
