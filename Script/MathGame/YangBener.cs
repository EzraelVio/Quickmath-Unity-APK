using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YangBener : MonoBehaviour
{
    public GameObject QA;
    public GameObject timer;
    public GameObject[] AddDec;
    public bool correction = false;
    public void needed(){
        if(correction){
            SoundManager.instance.ClickSfx();
            QA.GetComponent<QuestiontoAnswer>().correct_answer += 1;
            timer.GetComponent<Timer>().AddTime();
            AddDec[0].GetComponent<Animator>().SetTrigger("do");
            AddDec[0].GetComponent<Text>().text = "+" + timer.GetComponent<Timer>().add.ToString();
        }
        else {
            SoundManager.instance.ClickSfx();
            QA.GetComponent<QuestiontoAnswer>().wrong_answer += 1;
            timer.GetComponent<Timer>().DecTime();
            AddDec[1].GetComponent<Animator>().SetTrigger("do");
            AddDec[1].GetComponent<Text>().text = "-" + timer.GetComponent<Timer>().dec.ToString();
        }
    }
}
