using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Back;
    public GameObject Graphy;
    public GameObject OptionsMenu;
    public AudioMixer audioMixer;
    public GameObject FPSSet;
    public GameObject GameShop;
    public GameObject Coins;

    public Text moneyText;


    private bool stateFPS = false;

    private void Update()
    {
        ShowMoney();
    }


    void ShowMoney()
    {
        moneyText.text = PlayerMecanics.money.ToString();
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShopForGame()
    {
        ActiveElementsMenu(false);
        Back.SetActive(true);
        ActiveElementsShop(true);
        
    }

    public void OtionsGame()
    {
        ActiveElementsMenu(false);
        Back.SetActive(true);
        ActiveElementsOptionsMenu(true);


    }

    public void BackToMenu()
    {
        ActiveElementsMenu(true);
        Back.SetActive(false);
        ActiveElementsOptionsMenu(false);
        ActiveElementsShop(false);
    }

    private void ActiveElementsMenu(bool state)
    {
        Menu.SetActive(state);
    }

    private void ActiveElementsShop(bool state)
    {
        GameShop.SetActive(state);
        Coins.SetActive(state);
        ShowMoney();
    }

    private void ActiveElementsOptionsMenu(bool state)
    {
        OptionsMenu.SetActive(state);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void Sound()
    {
        AudioListener.pause = !AudioListener.pause;
    }

    public void SetFPS()
    {
        stateFPS = !stateFPS;
        ActiveFPS(stateFPS);
    }

    public void ActiveFPS(bool state)
    {
        Graphy.SetActive(state);
    }
}
