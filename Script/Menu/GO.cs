using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GO : MonoBehaviour
{
    public GameObject[] game;
    private float st = 3;
    private bool goo = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(goo)go();
    }

    public void lmao(){
        SoundManager.instance.ClickSfx();
        goo = true;
    }

    private void go(){
        if(st > 1)st -= Time.deltaTime;
        else {
            st = 0;
            game[0].SetActive(false);
            game[1].SetActive(true);
        }
        float seconds = Mathf.FloorToInt(st % 60);
        GetComponent<Text>().text = seconds.ToString();
    }
}
