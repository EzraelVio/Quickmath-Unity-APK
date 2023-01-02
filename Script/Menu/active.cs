using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class active : MonoBehaviour
{
    public void activethisshit(){
        this.gameObject.SetActive(true);
    }
    public void deactivethisshit(){
        this.gameObject.SetActive(false);
    }
}
