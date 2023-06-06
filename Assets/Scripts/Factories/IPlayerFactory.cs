using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerFactory : IService
{
    Player Create(Vector3 pos);
}
