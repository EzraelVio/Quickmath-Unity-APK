using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject[] Deact;
    public GameObject newScore;
    public ScoringSystem totalScore;
    public Score secore;
    private int maxindex;
    private float time = 0;
    private int index = 0;
    public bool NewScore = false;

    [Header("NewScoreCheck")]
    public int placement = 0;
    // Start is called before the first frame update
    void Start()
    {
        maxindex = 0;
        starting();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(index < maxindex){
            if(time > 0.5){
                Deact[index].SetActive(true);
                index += 1;
                time = 0;
            }
        }
        if(NewScore){
            if(time > 1){
                newScore.SetActive(true);
                NewScore = false;
            }
        } 
    }

    void starting(){
        foreach (GameObject a in Deact)
        {
            a.SetActive(false);
            maxindex += 1;
        }
    }

    void newScoreCheck(){
        while(!NewScore){
            if(secore.score[placement] < placement){
                NewScore = true;
            }
            else placement += 1;
        }
    }
}
