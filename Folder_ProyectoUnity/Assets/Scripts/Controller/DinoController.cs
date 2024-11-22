using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

public class DinoController : MonoBehaviour
{
    [Header("DoTween")]
    [SerializeField] private float duration = 0.5f;
    [SerializeField] private Ease EaseValue = Ease.Linear;
    [SerializeField] private Vector3 shrinkScale;
    private Vector3 originalScale;

    [Header("NavMesh")]
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private int currentPointIndex = 0;
    private NavMeshAgent agent;


    [Header("Sounds")]
    [SerializeField] private SoundsSO dinoSounds;


    private void Start() 
    {
        originalScale = transform.localScale;
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            MoveToNextPoint();
        }
    }
    void MoveToNextPoint()
    {
        if (patrolPoints.Length == 0) 
        {
            return;
        }

        agent.SetDestination(patrolPoints[currentPointIndex].position);
        currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
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