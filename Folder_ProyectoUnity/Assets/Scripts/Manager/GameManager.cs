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


    private void OnEnable()
    {
        PlayerController.OnVictory += LoadVictoryScene;
        UIcontroller.OnDefeat += LoadDefeatScene;
        PlayerController.OnDefeat += LoadDefeatScene;
    }
    private void OnDisable()
    {
        PlayerController.OnVictory -= LoadVictoryScene;
        UIcontroller.OnDefeat -= LoadDefeatScene;
        PlayerController.OnDefeat -= LoadDefeatScene;
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

}