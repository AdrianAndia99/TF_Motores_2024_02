using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

public class DinoController : MonoBehaviour
{
    [Header("General Settings")]
    [SerializeField] private bool isStaticDino = false;

    [Header("DoTween")]
    [SerializeField] private float duration = 0.5f;
    [SerializeField] private Ease EaseValue = Ease.Linear;
    [SerializeField] private Vector3 shrinkScale;
    private Vector3 originalScale;

    [Header("NavMesh")]
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private int currentPointIndex = 0;
    [SerializeField] private Transform player;
    private NavMeshAgent agent;
    private bool isChasingPlayer = false;

    [Header("Sounds")]
    [SerializeField] private SoundsSO dinoSounds;
    private bool isPlayingSounds = false;

    private void Start()
    {
        originalScale = transform.localScale;

        if (!isStaticDino)
        {
            agent = GetComponent<NavMeshAgent>();
        }
    }
    void Update()
    {
        if (isChasingPlayer && !isStaticDino)
        {
            ChasePlayer();
        }
        else if (!isStaticDino && !agent.pathPending && agent.remainingDistance < 0.5f)
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
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ModifyDino());
            if (!isStaticDino)
            {
                StopChasingPlayer();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!isStaticDino)
            {
                StartChasingPlayer();
            }

            if (!isPlayingSounds)
            {
                StartCoroutine(PlayDinoSoundsSequentially());
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!isStaticDino)
            {
                StopChasingPlayer();
            }
        }
    }
    private IEnumerator ModifyDino()
    {
        transform.DOScale(shrinkScale, duration).SetEase(EaseValue);
        yield return new WaitForSeconds(duration);
        transform.DOScale(originalScale, duration).SetEase(EaseValue);
    }
    private IEnumerator PlayDinoSoundsSequentially()
    {
        isPlayingSounds = true;

        for (int i = 0; i < dinoSounds.soundEffectsAccess.Length; i++)
        {
            dinoSounds.PlaySoundAt(i);
            yield return new WaitForSeconds(dinoSounds.GetClipLengthAt(i) + 2f);
        }

        isPlayingSounds = false;
    }
    private void StartChasingPlayer()
    {
        isChasingPlayer = true;
        agent.stoppingDistance = 1f;
    }
    private void StopChasingPlayer()
    {
        isChasingPlayer = false;
        agent.stoppingDistance = 0f;
        MoveToNextPoint();
    }
    private void ChasePlayer()
    {
        if (player != null)
        {
            agent.SetDestination(player.position);
        }
    }
}