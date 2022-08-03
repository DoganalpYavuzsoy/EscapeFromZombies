using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class MenuScript : MonoBehaviour {
    
    public void PlayButton() {
        
        SceneManager.LoadScene(1);


    }

    public void QuitButton() {
        //Application.Quit();
        Debug.Log("asasdfasdf");
        UnityEditor.EditorApplication.isPlaying = false;
    }
    public void DeathButton()
    {
        SceneManager.LoadScene(0);

    }
}


