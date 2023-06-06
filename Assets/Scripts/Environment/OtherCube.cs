using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class OtherCube : BaseCube
{
    private void Start()
    {
        _meshRenderer.material = Materials[(int)Power];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<OtherCube>(out OtherCube cube) && Power == cube.Power)
        {
            UpPower(1);
            Destroy(cube.gameObject);
        }
    }
}
