using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] public static bool buttonPressed;
    public AudioSource buttonPressedAudio;

    public void ButtonDown()
    {
        buttonPressed = true;
    }

    public void ButtonUp()
    {
        buttonPressed = false;
        SceneManager.LoadScene(1);
    }
}