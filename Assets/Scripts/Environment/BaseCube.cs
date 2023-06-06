using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCube : MonoBehaviour
{
    public MeshRenderer _meshRenderer;
    public ECubePower Power;
    public bool IsActive = true;

    [SerializeField] protected Material[] Materials;

    public virtual void UpPower(int PowerLevel)
    {
        Power += PowerLevel;
        if (Power < ECubePower.e)
            CubeRefresh();
    }

    public virtual void DownPower(int PowerLevel)
    {
        Power -= PowerLevel;
        if (Power < 0)
            Destroy(gameObject);
        else
            CubeRefresh();
    }

    public virtual void SetPower(ECubePower power)
    {
        Power = power;
        if (Power > 0)
            CubeRefresh();
    }

    public virtual void CubeRefresh()
    {
        _meshRenderer.material = Materials[(int)Power];
    }
}