using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInput : IService
{
    void Touch();
    void EnableInput();
    void DisableInput();
}
