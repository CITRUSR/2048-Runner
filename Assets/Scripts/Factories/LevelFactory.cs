using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFactory : ILevelFactory
{
    private LevelsConfig _levelsConfig;

    public LevelFactory(LevelsConfig levelsConfig)
    {
        _levelsConfig = levelsConfig;
    }

    public Level Create(int id)
    {
        if (_levelsConfig.Levels.Length <= id)
            return null;

        var level = Object.Instantiate(_levelsConfig.Levels[id]);
        level.transform.position = Vector3.zero;

        return level;
    }
}
