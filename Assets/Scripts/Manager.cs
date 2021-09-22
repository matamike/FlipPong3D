using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Manager : MonoBehaviour{

    public void PVP() {
        Debug.Log("Loading PVP Scene");
        SceneManager.LoadScene("PVP");
    }

    public void PlayerVSAI(){
        SceneManager.LoadScene("Player_Vs_AI");
    }

    public void Exit(){
        Debug.Log("Exiting Game!");
        Application.Quit(); //Works Only on Standalone Build.
    }
}
