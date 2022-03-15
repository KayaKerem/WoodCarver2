using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "ScriptableObjects/PlayerSettings")]
public class PlayerSettings : ScriptableObject
{
    public bool isPlaying;
    public bool isDeath;
    public float ForwardSpeed;
    public float sensitivity;
    public int score;
    public int finishScore;
    public int level;
    public int howManyObjectsOpend = 0;
    public int index = 0;
}
