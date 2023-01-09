using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStarter : MonoBehaviour
{
    public GameObject[] game;
    private float startingTimer = 3;
    private bool timerStart = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timerStart)go();
    }

    public void starto(){
        SoundManager.instance.ClickSfx();
        timerStart = true;
    }

    private void go(){
        if(startingTimer > 1)startingTimer -= Time.deltaTime;
        else {
            startingTimer = 0;
            game[0].SetActive(false);
            game[1].SetActive(true);
        }
        float seconds = Mathf.FloorToInt(startingTimer % 60);
        GetComponent<Text>().text = seconds.ToString();
    }
}
