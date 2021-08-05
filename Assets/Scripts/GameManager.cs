using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerMecanics movement;
    public GameMenu gmenu;
    public float restartLevelDelay = 2f;


    SavePrefs sp = new SavePrefs();
    void NewMothod()
    {
        sp.Save();
    }


    public void EndGame()
    {
        movement.enabled = false;
        gmenu.Open(false,false);
        sp.LoadMoney();
        //Invoke("RestartLevel", restartLevelDelay);
    }

    public void Pause()
    {
        movement.enabled = false;
        gmenu.Open(true,false);
    }

    //public void RestartLevel()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //}

    public void Finish()
    {
        movement.enabled = false;
        NewMothod();
        gmenu.Open(false, true);
    }
}
