using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Levels", menuName = "2048 Runner/Levels", order = 0)]
public class LevelsConfig : ScriptableObject
{
    public Level[] Levels;
}