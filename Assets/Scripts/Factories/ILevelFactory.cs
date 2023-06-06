using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelFactory : IService
{
    Level Create(int id);
}
