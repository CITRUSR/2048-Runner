using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoader : IService
{
    object Load<T>(object dataDefault);
}
