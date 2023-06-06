using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCounter : IService
{
    public int Gems { get; private set; }

    public void SetGem(int count)
    {
        Gems = count;
    }

    public void AddGem(int count)
    {
        Gems += count;
    }

    public void RemoveGem(int count)
    {
        Gems -= count;
    }
}
