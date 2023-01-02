using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreData 
{
    public string[] name;
    public int[] scores;

    public ScoreData (Score score)
    {
        name = new string[5];
        scores = new int[5];

        for(int i = 0; i < 5 ; i++){
            name[i] = score.name[i];
            scores[i] = score.score[i];
        }
    }
}

