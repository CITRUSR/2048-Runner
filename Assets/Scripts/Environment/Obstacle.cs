using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<BaseCube>(out BaseCube cube))
        {
            cube.DownPower(1);
        }
    }
}
