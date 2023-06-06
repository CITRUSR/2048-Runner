using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GemWindow : Window
{
    [SerializeField] private TextMeshProUGUI _gemText;

    public void SetGemText(int gem)
    {
        _gemText.text = gem.ToString();
    }
}
