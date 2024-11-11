using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerControler.OnVictory += LoadVictoryScene;
        PlayerControler.OnDefeat += LoadDefeatScene;
        PlayerControler.OnCollect += CollectItem;
    }
    private void OnDisable()
    {
        PlayerControler.OnVictory -= LoadVictoryScene;
        PlayerControler.OnDefeat -= LoadDefeatScene;
        PlayerControler.OnCollect -= CollectItem;
    }

    private void LoadVictoryScene()
    {
        SceneManager.LoadScene("Victory");
    }

    private void LoadDefeatScene()
    {
        SceneManager.LoadScene("Defeat");
    }

    private void CollectItem()
    {
        Debug.Log("wazaaaa");
    }
}