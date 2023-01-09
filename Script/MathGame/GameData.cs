using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour
{
    [Header("Game Objects")]
    public QuestiontoAnswer questiontoAnswer;
    public Timer timer;
    [Header("Difficulty Controller")]
    [Header("Variable")]
    //variable from 1 digit to 2 digit then 3 digit
    public int difficultyVariable1;
    public int difficultyVariable2;
    [Header("Equator")]
    // equation +- < dif1 +-x < dif2 +-x/
    public int difficultyEquator1;
    public int difficultyEquator2;
    [Header("Start Timer")]
    public float start;
    [Header("Add and Decrease")]
    public float add;
    public float dec;
    // Start is called before the first frame update
    void Start()
    {
        questiontoAnswer.difficultyVariable1 = difficultyVariable1;
        questiontoAnswer.difficultyVariable2 = difficultyVariable2;
        questiontoAnswer.difficultyEquator1 = difficultyEquator1;
        questiontoAnswer.difficultyEquator2 = difficultyEquator2;
        timer.timer = start;
        timer.add = add;
        timer.dec = dec;
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
