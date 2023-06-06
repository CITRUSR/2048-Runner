using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    public virtual void ShowWindow()
    {
        gameObject.SetActive(true);
    }

    public virtual void HideWindow()
    {
        gameObject.SetActive(false);
    }
}
