using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIcontroller : MonoBehaviour
{
    [SerializeField] private GameObject panelPause;
    [SerializeField] private TMP_Text scoreText;

    private void OnEnable()
    {
        PlayerController.OnCollect += UpdateScore;
        PlayerController.OnCollision += UpdateLife;
    }
    private void OnDisable()
    {
        PlayerController.OnCollect -= UpdateScore;
        PlayerController.OnCollision -= UpdateLife;

    }
    public void Pause()
    {
        panelPause.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void Resume()
    {
        panelPause.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void UpdateLife()
    {


    }
    public void UpdateScore(int newScore)
    {
        scoreText.text = newScore.ToString();
        newScore = int.Parse(scoreText.text);
        Debug.Log("Score actualizado: " + newScore);
    }
}