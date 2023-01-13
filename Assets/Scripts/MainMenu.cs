using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string playGameLevel;
    public AudioSource buttonSound;

    public void PlayGame()
    {
        Application.LoadLevel(playGameLevel);
        buttonSound.Play();
    }


    public void QuitGame()
    {
        Application.Quit();
        buttonSound.Play();
    }
}
