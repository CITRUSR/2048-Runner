using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaver : IService
{
    void Save(object data);
}
