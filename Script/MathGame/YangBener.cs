using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YangBener : MonoBehaviour
{
    public QuestiontoAnswer questiontoAnswer;
    public Timer timer;
    public GameObject[] AddDec;
    public bool correction = false;
    public void needed(){
        if(correction){
            SoundManager.instance.ClickSfx();
            questiontoAnswer.correct_answer += 1;
            timer.AddTime();
            AddDec[0].GetComponent<Animator>().SetTrigger("do");
            AddDec[0].GetComponent<Text>().text = "+" + timer.add.ToString();
        }
        else {
            SoundManager.instance.ClickSfx();
            questiontoAnswer.wrong_answer += 1;
            timer.DecTime();
            AddDec[1].GetComponent<Animator>().SetTrigger("do");
            AddDec[1].GetComponent<Text>().text = "-" + timer.dec.ToString();
        }
    }
}
