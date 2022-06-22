using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menuController : MonoBehaviour
{
    public void Jugar(){
        SceneManager.LoadScene  ("sceneOne");
    }
    public void Salir(){
        Application.Quit();
    }
}
