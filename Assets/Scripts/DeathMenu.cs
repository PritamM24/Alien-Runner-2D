using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    public string mainmenu;
    public AudioSource clickSound;

    public void Restart()
    {
        FindObjectOfType<GameManager>().Reset();
        clickSound.Play();
    }

    public void QuitToMain()
    {
        Application.LoadLevel(mainmenu);
        clickSound.Play();
    }
}
