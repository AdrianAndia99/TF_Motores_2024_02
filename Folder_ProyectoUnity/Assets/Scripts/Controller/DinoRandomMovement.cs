using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DinoRandomMovement : MonoBehaviour
{
    NavMeshAgent agent;
    //[SerializeField] private Animator dinoAnimator;
    [SerializeField] private float range = 10f;
    [SerializeField] private float waitTime = 1.5f;
    [SerializeField] private float stayTime = 1f;

    bool waiting;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
       // dinoAnimator = GetComponent<Animator>();
        moveToPoint();
    }

    private void Update() 
    {
        if (!waiting && !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance && agent.hasPath)
        {
            if (Random.value < stayTime)
            {
                StartCoroutine(WaitMove());
            }
            else
            {
                moveToPoint();
            }
        }
        else if (!agent.hasPath && !waiting)
        {
            moveToPoint();
        }

       // dinoAnimator.SetBool("isWalking", agent.velocity.sqrMagnitude > 0.1f);
    }

    private void moveToPoint()
    {
        Vector3 randomDirection = Random.insideUnitSphere * range;
        randomDirection += transform.position;
        NavMeshHit hit;

        if(NavMesh.SamplePosition(randomDirection, out hit, range, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
           // dinoAnimator.SetBool("isWalking",true);
        }
    }

    private IEnumerator WaitMove()
    {
        waiting = true;
        //dinoAnimator.SetBool("isWalking", false);

        yield return new WaitForSeconds(waitTime);
        moveToPoint();
        waiting = false;
    }
}