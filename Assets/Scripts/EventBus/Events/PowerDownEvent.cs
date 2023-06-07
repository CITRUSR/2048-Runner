using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDownEvent
{
    public readonly ECubePower Power;

    public PowerDownEvent(ECubePower _newPower)
    {
        Power = _newPower;
    }
}
