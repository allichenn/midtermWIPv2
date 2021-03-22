using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{
    public void loadGame(){
        SceneManager.LoadScene("levelOne");
    }

    public void goBack(){
        SceneManager.LoadScene("menu");
    }

    public void goInstructions(){
        SceneManager.LoadScene("instructions");
    }
}
