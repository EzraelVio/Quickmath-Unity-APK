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

        nilcheck();
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

    public void nilcheck(){
        if(name[0] == "" && score[0] == 0){
            name[0] = "Vio";
            score[0] = 25;
        }
        if(name[1] == "" && score[1] == 0){
            name[1] = "Rio";
            score[1] = 20;
        }
        if(name[2] == "" && score[2] == 0){
            name[2] = "Tio";
            score[2] = 15;
        }
        if(name[3] == "" && score[3] == 0){
            name[3] = "Gio";
            score[3] = 10;
        }
        if(name[4] == "" && score[4] == 0){
            name[4] = "Fio";
            score[4] = 5;
        }
        SaveBoard();
    }
}