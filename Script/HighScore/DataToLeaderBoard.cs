using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DataToLeaderBoard : MonoBehaviour
{
    void Start() {
        putScoreBoard();
    }

    public Score scores;
    public TextMeshProUGUI[] Name;
    public TextMeshProUGUI[] Score;

    public void putScoreBoard(){
        for(int i = 0 ; i < 5; i++){
            Name[i].text = scores.name[i];
            Score[i].text = scores.score[i].ToString();
        }
    }
}
