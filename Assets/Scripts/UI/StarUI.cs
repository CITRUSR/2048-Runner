using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarUI : MonoBehaviour
{
    [SerializeField] private Image _image;

    public void ActiveStar()
    {
        _image.color = new Vector4(_image.color.r, _image.color.g, _image.color.b, 1);
    }

    public void DisableStar()
    {
        _image.color = new Vector4(_image.color.r, _image.color.g, _image.color.b, 0.2f);
    }
}
