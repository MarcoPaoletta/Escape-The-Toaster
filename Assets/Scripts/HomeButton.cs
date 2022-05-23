using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButton : MonoBehaviour
{
    public void GoHome()
    {
        Fork.isAlive = true;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
