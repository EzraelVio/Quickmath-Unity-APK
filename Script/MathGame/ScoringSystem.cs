using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    public int scores;
    private string name;
    [Header("Game Objects")]
    public QuestiontoAnswer questiontoAnswer;
    public GameObject inputfield;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scores = (questiontoAnswer.correct_answer * 5) - questiontoAnswer.wrong_answer;
        GetComponent<Text>().text = scores.ToString();
    }
}
