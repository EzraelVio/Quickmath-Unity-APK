using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DataToLeaderBoard : MonoBehaviour
{
    [Header("Score Finder")]
    public GameObject scoreObject;
    private Score scores;
    void Awake() {
        if(scores == null) {
            scoreObject = GameObject.FindWithTag("ScoreData");
            scores = scoreObject.GetComponent<Score>();
        }
    }

    void Start() {
        scores.nilcheck();

        putScoreBoard();
    }

    public TextMeshProUGUI[] Name;
    public TextMeshProUGUI[] Score;

    public void putScoreBoard(){
        for(int i = 0 ; i < 5; i++){
            Name[i].text = scores.name[i];
            Score[i].text = scores.score[i].ToString();
        }
    }
}
