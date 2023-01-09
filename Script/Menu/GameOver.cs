using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject[] Deact;
    public GameObject newScore;
    public ScoringSystem totalScore;
    private int maxindex;
    private float time;
    private int index;
    public bool NewScore;
    private bool check;

    [Header("NewScoreCheck")]
    public int placement = 0;

    [Header("Score Finder")]
    private GameObject scoreObject;
    private Score secore;
    // Start is called before the first frame update
    void Awake()
    {
        index = 0;
        maxindex = 0;
        time = 0;
        NewScore = false;
        check = true;
        if(secore == null) {
            scoreObject = GameObject.FindWithTag("ScoreData");
            secore = scoreObject.GetComponent<Score>();
        }
        starting();

        secore.nilcheck();
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
        if(check){
            newScoreCheck();
            if(NewScore){
                if(time > 1){
                    newScore.SetActive(true);
                    check = false;
                }
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

    public void newScoreCheck(){
        while(!NewScore && placement < 5 && totalScore.scores != 0){
            if(secore.score[placement] < totalScore.scores){
                Debug.Log(placement);
                NewScore = true;
            }
            else placement += 1;
        }
    }
}
