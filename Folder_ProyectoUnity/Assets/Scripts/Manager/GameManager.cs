using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioClipSO clipMenu;
    [SerializeField] private AudioClipSO clipGame;

    private void OnEnable()
    {
        PlayerController.OnVictory += LoadVictoryScene;
        PlayerController.OnDefeat += LoadDefeatScene;
    }
    private void OnDisable()
    {
        PlayerController.OnVictory -= LoadVictoryScene;
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