using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject QA;
    public GameObject timer;
    [Header("Difficulty Controller")]
    [Header("Variable")]
    //variable from 1 digit to 2 digit then 3 digit
    public int difv1;
    public int difv2;
    [Header("Equator")]
    // equation +- < dif1 +-x < dif2 +-x/
    public int dife1;
    public int dife2;
    [Header("Start Timer")]
    public float start;
    [Header("Add and Decrease")]
    public float add;
    public float dec;
    // Start is called before the first frame update
    void Start()
    {
        QA.GetComponent<QuestiontoAnswer>().difv1 = difv1;
        QA.GetComponent<QuestiontoAnswer>().difv2 = difv2;
        QA.GetComponent<QuestiontoAnswer>().dife1 = dife1;
        QA.GetComponent<QuestiontoAnswer>().dife2 = dife2;
        timer.GetComponent<Timer>().timer = start;
        timer.GetComponent<Timer>().add = add;
        timer.GetComponent<Timer>().dec = dec;
    }

    public void restart(){
        SoundManager.instance.ClickSfx();
        SceneManager.LoadScene("MathGame");
    }

    public void MainMenu(){
        SoundManager.instance.ClickSfx();
        SceneManager.LoadScene("Main Menu");
    }
}
