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

    public GameOver gameover;
    public ScoringSystem scoringsystem;
    public Score secore;
    public void EnterNameToLeaderBoard(){
        secore.name[gameover.placement] = GetComponent<InputField>().text;
        secore.score[gameover.placement] = scoringsystem.scores;
        secore.SaveBoard();
    }
}
