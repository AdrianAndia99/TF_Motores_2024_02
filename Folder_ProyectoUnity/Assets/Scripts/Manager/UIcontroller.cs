using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class UIcontroller : MonoBehaviour
{
    [Header("Componentes TextMeshPro")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text lifeText;

    [Header("Panel Pausa")]
    [SerializeField] private GameObject panelPause;
    [SerializeField] private RectTransform panelTransform;
    [SerializeField] private float topPosY, centerPositionY;
    [SerializeField] private float tweenDuration;
    public static event Action OnDefeat;
    public static event Action OnFinal;
    private int currentScore = 0;
    private int currentLive = 5;

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
        PausePanelIntro();
    }
    public void Resume()
    {
        PausePanelOutro();
    }

    public void UpdateLife(int lifeDown)
    {
        currentLive -= lifeDown;
        lifeText.text = currentLive.ToString();
        Debug.Log("Vida Actualizada: " + lifeDown);
        if(currentLive == 0)
        {
            OnDefeat?.Invoke();
        }
    }
    public void UpdateScore(int scoreAdd)
    {
        currentScore += scoreAdd;
        scoreText.text = currentScore.ToString();
        Debug.Log("Score actualizado: " + scoreAdd);
        if(currentScore == 10)
        {
            OnFinal?.Invoke();
        }

    }
    public void PausePanelIntro()
    {
        panelPause.SetActive(true);
        Time.timeScale = 0.0f;
        panelTransform.DOAnchorPosY(centerPositionY,tweenDuration).SetUpdate(true);
    }

    public void PausePanelOutro()
    {
         panelTransform.DOAnchorPosY(topPosY, tweenDuration).SetUpdate(true).OnComplete(() =>
        {
            panelPause.SetActive(false);
            Time.timeScale = 1;
        });
    }
}