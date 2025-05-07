using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;


[Serializable]
public class Level
{
    [UnityEngine.Range(1, 11)]
    public int partCount = 11;

    [UnityEngine.Range(0, 11)]
    public int deathPartCount = 1;

    
}

[CreateAssetMenu(fileName = "NewStage",menuName = "Scriptable Objects/Stage")]
public class Stage : ScriptableObject
{
    public Color stageBackgroundColor = Color.white;
    public Color stageLevelPartColor = Color.white;
    public Color stageball = Color.white;
    public List<Level> levels = new List<Level>();


}
