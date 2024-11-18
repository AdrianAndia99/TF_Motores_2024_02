using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DinoController : MonoBehaviour
{
    [Header("DoTween")]
    [SerializeField] private float duration = 0.5f;
    [SerializeField] private Ease EaseValue = Ease.Linear;
    [SerializeField] private Vector3 shrinkScale;
    private Vector3 originalScale;


    [SerializeField] private SoundsSO dinoSounds;


    private void Start() 
    {
        originalScale = transform.localScale;
    }
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ModifyDino());
        }
    }
     private IEnumerator ModifyDino()
    {
        transform.DOScale(shrinkScale, duration).SetEase(EaseValue);
        yield return new WaitForSeconds(duration);
        transform.DOScale(originalScale, duration).SetEase(EaseValue);
    }
}