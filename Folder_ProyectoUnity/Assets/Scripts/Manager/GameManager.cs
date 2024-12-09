using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioClipSO clipMenu;
    [SerializeField] private AudioClipSO clipGame;
    [SerializeField] private AudioClipSO clipVictory;
    [SerializeField] private AudioClipSO clipDefeat;

    [SerializeField] private GameObject dino1;
    [SerializeField] private GameObject dino2;
    [SerializeField] private GameObject dino3;
    [SerializeField] private GameObject dino4;
    [SerializeField] private GameObject dino5;
    [SerializeField] private GameObject dino6;
    [SerializeField] private GameObject dino7;

    [SerializeField] private GameObject bossDino;

    private void OnEnable()
    {
        PlayerController.OnVictory += LoadVictoryScene;
        UIcontroller.OnDefeat += LoadDefeatScene;
        PlayerController.OnDefeat += LoadDefeatScene;
        UIcontroller.OnFinal += FinalEscape;
        Trucoteca.OnFinal += FinalEscape;
    }
    private void OnDisable()
    {
        PlayerController.OnVictory -= LoadVictoryScene;
        UIcontroller.OnDefeat -= LoadDefeatScene;
        PlayerController.OnDefeat -= LoadDefeatScene;
        UIcontroller.OnFinal -= FinalEscape;
        Trucoteca.OnFinal -= FinalEscape;
    }

    private void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if(currentScene == "Menu")
        {
            clipMenu.PlayLoop();
        }
        else if(currentScene == "Game")
        {
            clipGame.PlayLoop();
        }
        else if(currentScene == "Victory")
        {
            clipVictory.PlayOneShoot();
        }
        else if(currentScene == "Defeat")
        {
            clipDefeat.PlayOneShoot();
        }
    }

    private void LoadVictoryScene()
    {
        SceneManager.LoadScene("Victory");
    }

    private void LoadDefeatScene()
    {
        SceneManager.LoadScene("Defeat");
    }

    public void SceneChange(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Saliendo");
    }
    public void FinalEscape()
    {
        dino1.SetActive(false);
        dino2.SetActive(false);
        dino3.SetActive(false);
        dino4.SetActive(false);
        dino5.SetActive(false);
        dino6.SetActive(false);
        dino7.SetActive(false);
        bossDino.SetActive(true);
    }
}