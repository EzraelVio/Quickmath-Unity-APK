using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStart : MonoBehaviour
{
    public GameObject[] Deact;
    private void Awake() {
        foreach (GameObject a in Deact)
        {
            a.SetActive(false);
        }
        Deact[0].SetActive(true);
    }
}
