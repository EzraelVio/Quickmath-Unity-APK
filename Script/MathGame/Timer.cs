using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text text;
    [Header("Start Time")]
    public float timer;

    [Header("plus minus time")]
    public float add;
    public float dec;

    [Header("game over")]
    public GameObject game;
    private void Awake() {
        text = GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time();
    }

    private void time(){
        if(timer > 1)timer -= Time.deltaTime;
        else {
            timer = 0;
            game.SetActive(true);
            game.GetComponent<GameOver>().newScoreCheck();
        }
        float minutes = Mathf.FloorToInt(timer / 60);
        float seconds = Mathf.FloorToInt(timer % 60);
        text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void AddTime(){
        timer += add;
    }

    public void DecTime(){
        timer -= dec;
    }

}
