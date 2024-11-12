using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicBackGround : MonoBehaviour
{
    [SerializeField] private AudioClipSO clipMenu;
    [SerializeField] private AudioClipSO clipGame;
    
    void Start()
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
}