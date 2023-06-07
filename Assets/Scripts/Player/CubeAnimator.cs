using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void PlaySizeAnimation()
    {
        _animator.SetTrigger("Size");
    }
}
