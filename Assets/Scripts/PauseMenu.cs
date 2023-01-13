using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public string mainmenu;
    public GameObject pauseMenu;
    public AudioSource clickSound;

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        clickSound.Play();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        clickSound.Play();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        FindObjectOfType<GameManager>().Reset();
        clickSound.Play();
    }

    public void QuitToMain()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(mainmenu);
        clickSound.Play();
    }
}
