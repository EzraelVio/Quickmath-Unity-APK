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
    private int totalVariable(){
        if(difficulty() > 7) return 8;
        else if(difficulty() < 1) return 2;
        else return difficulty() + 1;
    }
    [Header("Random Number")]
    public int[] num = new int[8];
    [Header("Answer Box")]
    public GameObject[] answerbox;
    private float[] answerBox = new float[4];
    [Header("Question")]
    public string questiontoAnswer;
    public GameObject question;
    [Header("Answer")]
    public float Answer;
    [Header("Difficulty Controller")]
    [Header("Variable")]
    //variable from 1 digit to 2 digit then 3 digit
    public int difficultyVariable1;
    public int difficultyVariable2;
    [Header("Equator")]
    // equation +- < dif1 +-x < dif2 +-x/
    public int difficultyEquator1;
    public int difficultyEquator2;
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
        int Tot = totalVariable();
        int dif = difficulty();
        for(int i = 0;i < Tot;i++){
            if(dif < difficultyVariable1){
                num[i] = Random.Range(1,10);
            }
            else if(dif >= difficultyVariable1 && dif < difficultyVariable2){
                num[i] = Random.Range(1,100);
            }
            else num[i] = Random.Range(1,1000);
        }
    }

    public string equation_generator(){
        int Tot = totalVariable();
        int dif = difficulty();
        string eg = num[0].ToString();
        for(int i = 0;i < Tot - 1;i++){
            if(dif < difficultyEquator1){
                int random = Random.Range(0,2);
                eg = eg + equator(random) + num[i+1].ToString();
            }
            else if(dif >= difficultyEquator1 || dif < difficultyEquator2){
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
        if (random == 0) return " + ";
        else if(random == 1) return " - ";
        else if (random == 2) return " * ";
        else return "/";
    }

    void generate_answer(){
        int rightAnswer = Random.Range(0,4);
        for (int i = 0; i < 4; i++){
            if(i == rightAnswer){
                answerBox[i] = Answer;
                answerbox[i].GetComponent<YangBener>().correction = true;
            }
            else{
                int eq = Mathf.FloorToInt(Random.Range(Answer * (-7) /10, Answer * 7 / 10));
                answerBox[i] = Answer + eq;
                if(answerBox[i] == Answer) answerBox[i] += 1;
                answerbox[i].GetComponent<YangBener>().correction = false;
            }
            answerbox[i].GetComponent<Text>().text = answerBox[i].ToString();
        }
        while(answerBox[0] == answerBox[1] || answerBox[0] == answerBox[2] || answerBox[0] == answerBox[3] || 
              answerBox[1] == answerBox[2] || answerBox[1] == answerBox[3] || 
              answerBox[2] == answerBox[3]){
                answercheck(rightAnswer);
              }
    }

    void answercheck(int a){
        for(int i = 0; i < 4; i++){
            if(i != a){
                for(int u = 0; u < i; u++){
                    while(answerBox[i] == answerBox[u] || answerBox[i] == Answer) answerBox[i] += 1;
                }
                answerbox[i].GetComponent<Text>().text = answerBox[i].ToString();
            }
        }
    }

    public void answering(){
        Number_Generator();
        questiontoAnswer = equation_generator();
        question.GetComponent<Text>().text = questiontoAnswer;
        Answer = Evaluate(questiontoAnswer);
        generate_answer();
    }
}
