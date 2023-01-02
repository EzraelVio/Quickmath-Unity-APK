using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    public int scores;
    private string name;
    [Header("Game Objects")]
    public GameObject QA;
    public GameObject inputfield;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scores = (QA.GetComponent<QuestiontoAnswer>().correct_answer * 5) - QA.GetComponent<QuestiontoAnswer>().wrong_answer;
        GetComponent<Text>().text = scores.ToString();
    }
}
