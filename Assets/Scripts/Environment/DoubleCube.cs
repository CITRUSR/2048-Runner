using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleCube : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (TryGetComponent<BaseCube>(out BaseCube cube) && cube.IsActive)
        {
            cube.UpPower(1);
            Destroy(gameObject);
        }
    }
}
