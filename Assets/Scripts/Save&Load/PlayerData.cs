using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
    public int score;
    public string nameOfBoi;
    public PlayerData(UIManager player)
    {
        score = player.HighScore;
        nameOfBoi = player.nameOfBoi;
    }
}
