using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCalculator : IStarCalculator
{
    public int CalculateStarCount(ECubePower playerCubePower, Level complitedLevel)
    {
        if (playerCubePower >= complitedLevel.MaxPowerLevel)
        {
            return 3;
        }
        else if (playerCubePower >= complitedLevel.MaxPowerLevel - 2)
        {
            return 2;
        }
        else if (playerCubePower >= complitedLevel.MaxPowerLevel - 4)
        {
            return 1;
        }

        return 0;
    }
}
