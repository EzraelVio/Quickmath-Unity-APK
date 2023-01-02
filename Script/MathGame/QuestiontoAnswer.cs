using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestiontoAnswer : MonoBehaviour
{
    [Header("Game Data")]
    public int correct_answer;
    public int wrong_answer;

    public int difficulty(){
        if(correct_answer < 5) return 1;
        else return correct_answer / 5;
    }
    private int tot(){
        if(difficulty() > 7) return 8;
        else if(difficulty() < 1) return 2;
        else return difficulty() + 1;
    }
    [Header("Random Number")]
    public int[] num = new int[8];
    [Header("Answer Box")]
    public GameObject[] answerbox;
    private float[] ansb = new float[4];
    [Header("Question")]
    public string QA;
    public GameObject question;
    [Header("Answer")]
    public float Ans;
    [Header("Difficulty Controller")]
    [Header("Variable")]
    //variable from 1 digit to 2 digit then 3 digit
    public int difv1;
    public int difv2;
    [Header("Equator")]
    // equation +- < dif1 +-x < dif2 +-x/
    public int dife1;
    public int dife2;
    // Start is called before the first frame update
    void Start()
    {
        answering();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static float Evaluate(string expression)  
       {  
           System.Data.DataTable table = new System.Data.DataTable();  
           table.Columns.Add("expression", string.Empty.GetType(), expression);  
           System.Data.DataRow row = table.NewRow();  
           table.Rows.Add(row);  
           return float.Parse((string)row["expression"]);  
       }

    public void Number_Generator(){
        // data filling
        int Tot = tot();
        int dif = difficulty();
        for(int i = 0;i < Tot;i++){
            if(dif < difv1){
                num[i] = Random.Range(1,10);
            }
            else if(dif >= difv1 && dif < difv2){
                num[i] = Random.Range(1,100);
            }
            else num[i] = Random.Range(1,1000);
        }
    }

    public string equation_generator(){
        int Tot = tot();
        int dif = difficulty();
        string eg = num[0].ToString();
        for(int i = 0;i < Tot - 1;i++){
            if(dif < dife1){
                int random = Random.Range(0,2);
                eg = eg + equator(random) + num[i+1].ToString();
            }
            else if(dif >= dife1 || dif < dife2){
                int random = Random.Range(0,3);
                eg = eg + equator(random) + num[i+1].ToString();
            }
            else {
                int random = Random.Range(0,4);
                eg = eg + equator(random) + num[i+1].ToString();
            }
        }
        return eg;
    }

    string equator(int random){
        // if(random >= 0 && random <= 3){
        //     switch (random){
        //         case 0:
        //             return " + ";
        //         case 1:
        //             return " - ";
        //         case 2:
        //             return " * ";
        //         case 3:
        //             return " / ";
        //     }
        // }else return "";
        if (random == 0) return " + ";
        else if(random == 1) return " - ";
        else if (random == 2) return " * ";
        else return "/";
    }

    void generate_answer(){
        int rightAnswer = Random.Range(0,4);
        for (int i = 0; i < 4; i++){
            if(i == rightAnswer){
                ansb[i] = Ans;
                answerbox[i].GetComponent<YangBener>().correction = true;
            }
            else{
                int eq = Mathf.FloorToInt(Random.Range(Ans * (-7) /10, Ans * 7 / 10));
                ansb[i] = Ans + eq;
                if(ansb[i] == Ans) ansb[i] += 1;
                answerbox[i].GetComponent<YangBener>().correction = false;
            }
            answerbox[i].GetComponent<Text>().text = ansb[i].ToString();
        }
        while(ansb[0] == ansb[1] || ansb[0] == ansb[2] || ansb[0] == ansb[3] || 
              ansb[1] == ansb[2] || ansb[1] == ansb[3] || 
              ansb[2] == ansb[3]){
                answercheck(rightAnswer);
              }
    }

    void answercheck(int a){
        for(int i = 0; i < 4; i++){
            if(i != a){
                for(int u = 0; u < i; u++){
                    while(ansb[i] == ansb[u] || ansb[i] == Ans) ansb[i] += 1;
                }
                answerbox[i].GetComponent<Text>().text = ansb[i].ToString();
            }
        }
    }

    public void answering(){
        Number_Generator();
        QA = equation_generator();
        question.GetComponent<Text>().text = QA;
        Ans = Evaluate(QA);
        generate_answer();
    }
}
