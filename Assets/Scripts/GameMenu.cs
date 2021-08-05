using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class GameMenu : MonoBehaviour
{
    private Rect windowRect = new Rect((Screen.width - 200) / 2, (Screen.height - 300) / 2, 200, 300);
    public new Camera camera;
    public PlayerMecanics movement;

    private bool show = false;
    private bool pause = false;
    private bool finish = false;

    public GUIStyle[] labelStyle;

    
    void OnGUI()
    {
        if (show && pause && !finish)
        {
            windowRect = GUI.Window(0, windowRect, DialogWindowPause, "");
        }
        if(show && !pause && !finish)
        { 
            windowRect = GUI.Window(0, windowRect, DialogWindow, ""); 
        }
        if (show && finish && !pause)
        {
            windowRect = GUI.Window(0, windowRect, DialogWindowFinish, "");
        }
            

    }

    void DialogWindow(int windowID) //for end game
    {
        GUI.Label(new Rect(5, 5, windowRect.width, 190),"",labelStyle[0]);

        camera.clearFlags = CameraClearFlags.SolidColor;
        camera.backgroundColor = Color.white;

        if (GUI.Button(new Rect(5, 200, windowRect.width - 10, 30), "Restart"))
        {
            SceneManager.LoadScene("SampleScene");
            show = false;
        }

        if (GUI.Button(new Rect(5, 240, windowRect.width - 10, 30), "Exit"))
        {
            SceneManager.LoadScene("Main_menu");
            Shop.counterRight = 0;
            show = false;
        }
    }


    void DialogWindowPause(int windowID) //for pause
    {
        GUI.Label(new Rect(5, 5, windowRect.width, 170), "", labelStyle[1]);

        if (GUI.Button(new Rect(5, 180, windowRect.width - 10, 30), "Continue"))
        {
            show = false;
            movement.enabled = true;
        }

        if (GUI.Button(new Rect(5, 220, windowRect.width - 10, 30), "Restart"))
        {
            SceneManager.LoadScene("SampleScene");
            show = false;
        }

        if (GUI.Button(new Rect(5, 260, windowRect.width - 10, 30), "Exit"))
        {
            SceneManager.LoadScene("Main_menu");
            show = false;
        }
    }
    void DialogWindowFinish(int windowID) //for end game
    {
        GUI.Label(new Rect(5, 5, windowRect.width, 190), "", labelStyle[2]);


        if (GUI.Button(new Rect(5, 200, windowRect.width - 10, 30), "New level"))
        {
            SceneManager.LoadScene("SampleScene");
            show = false;
        }

        if (GUI.Button(new Rect(5, 240, windowRect.width - 10, 30), "Exit"))
        {
            SceneManager.LoadScene("Main_menu");
            Shop.counterRight = 0;
            show = false;
        }
    }


    public void Open(bool pause, bool finish)
    {
        show = true;
        this.pause = pause;
        this.finish = finish;
    }

}


