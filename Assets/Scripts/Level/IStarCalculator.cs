using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStarCalculator : IService
{
    int CalculateStarCount(ECubePower playerCubePower, Level completedLevel);
}
