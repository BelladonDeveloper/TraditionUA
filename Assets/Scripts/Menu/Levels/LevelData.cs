using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Level")]
public class LevelData : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private int _level;
    [SerializeField] private string _levelName;

    public Sprite Sprite => _sprite;
    public int Level => _level;
    public string LevelName => _levelName;
}
