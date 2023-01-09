using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MMManager : MonoBehaviour
{
    [Header("Panel List")]
    public GameObject mainMenuPanel;
    public GameObject infoPanel;
    public GameObject scoreBoard;
    public GameObject credits;
    public GameObject infoPanelPageOne;
    public GameObject infoPanelPageTwo;

    void Start() {
        mainMenuPanel.SetActive(true);
        infoPanel.SetActive(false);
        scoreBoard.SetActive(false);
        credits.SetActive(false);
    }

    public void Play(){
        SoundManager.instance.ClickSfx();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Info() {
        SoundManager.instance.ClickSfx();
        mainMenuPanel.SetActive(false);
        infoPanel.SetActive(true);
        infoPanelPageOne.SetActive(true);
        infoPanelPageTwo.SetActive(false);
    }

    public void InfoPanelNext() {
        SoundManager.instance.ClickSfx();
        infoPanelPageOne.SetActive(false);
        infoPanelPageTwo.SetActive(true);
    }

    public void LeaderBoard() {
        SoundManager.instance.ClickSfx();
        mainMenuPanel.SetActive(false);
        scoreBoard.SetActive(true);
    }

    public void Credits(){
        SoundManager.instance.ClickSfx();
        mainMenuPanel.SetActive(false);
        credits.SetActive(true);
    }

    public void Back() {
        SoundManager.instance.ClickSfx();
        mainMenuPanel.SetActive(true);
        infoPanel.SetActive(false);
        scoreBoard.SetActive(false);
        credits.SetActive(false);
    }

    public void Quit() {
        SoundManager.instance.ClickSfx();
        Application.Quit();
    }
}
