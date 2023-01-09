using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WriteText : MonoBehaviour
{
    private string input;
    public void ReadStringInput(string s){
        input = s;
        Debug.Log(input);
    }
    [Header("Score Finder")]
    private GameObject scoreObject;
    private Score secore;

    private void Awake() {
        if(secore == null) {
            scoreObject = GameObject.FindWithTag("ScoreData");
            secore = scoreObject.GetComponent<Score>();
        }
    }

    public GameOver gameover;
    public ScoringSystem scoringsystem;
    public void EnterNameToLeaderBoard(){
        for(int i = 4; i > gameover.placement; i--){
            secore.name[i] = secore.name[i-1];
            secore.score[i] = secore.score[i-1];
        }
        secore.name[gameover.placement] = GetComponent<InputField>().text;
        secore.score[gameover.placement] = scoringsystem.scores;
        secore.SaveBoard();
    }
}
