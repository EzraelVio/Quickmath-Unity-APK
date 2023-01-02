using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    public string[] name = new string[5];
    public int[] score = new int[5];
    
    public static Score instance;
    void Awake() {
        if (instance != null)Destroy(gameObject);
        else instance = this;
        
        LoadScore();

        DontDestroyOnLoad(this.gameObject);
    }

    public void SaveBoard(){
        SaveScore.SaveBoard(this);
        Debug.Log("Saving Data, Top Data: " + name[0] + score[0]);
    }

    public void LoadScore(){
        ScoreData data = SaveScore.LoadScore();

        for(int i = 0 ; i < 5; i++){
            name[i] = data.name[i];
            score[i] = data.scores[i];
        }
    }
}