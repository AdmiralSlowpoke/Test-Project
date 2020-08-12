using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Level",menuName ="Level")]
public class Level : ScriptableObject
{
    public string levelText;
    public State state;
    public enum State { Complete, Open, Locked };//Статус кнопки
}
