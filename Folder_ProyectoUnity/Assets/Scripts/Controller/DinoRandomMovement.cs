using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DinoRandomMovement : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] private Animator dinoAnimator;
    [SerializeField] private float rango = 10f;
    [SerializeField] private float tiempoEspera = 1.5f;
    [SerializeField] private float quieto = 1f;

    bool esperando;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        dinoAnimator = GetComponent<Animator>();
        moverAlPunto();
    }

    private void Update() 
    {
        if (!esperando && !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance && agent.hasPath)
        {
            if (Random.value < quieto)
            {
                StartCoroutine(esperaYmueve());
            }
            else
            {
                moverAlPunto();
            }
        }
        else if (!agent.hasPath && !esperando)
        {
            moverAlPunto();
        }

        dinoAnimator.SetBool("isWalking", agent.velocity.sqrMagnitude > 0.1f);
    }

    private void moverAlPunto()
    {
        Vector3 randomDirection = Random.insideUnitSphere * rango;
        randomDirection += transform.position;
        NavMeshHit hit;

        if(NavMesh.SamplePosition(randomDirection, out hit, rango, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
            dinoAnimator.SetBool("isWalking",true);
        }
        else
        {
            Debug.LogWarning("No se encontró un punto válido en el rango especificado.");
        }
    }

    private IEnumerator esperaYmueve()
    {
        esperando = true;
        dinoAnimator.SetBool("isWalking", false);

        yield return new WaitForSeconds(tiempoEspera);
        moverAlPunto();
        esperando = false;
    }
}