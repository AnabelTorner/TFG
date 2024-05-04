using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateMachine : MonoBehaviour
{
    public enum State
    {
        Normal,
        Investigate,
        Wait,
        Chase
    }

    public Transform[] waypoints;
    public float secondsWaiting = 5f;
    public float chaseSpeed = 5f;

    private State currentState;

    private NavMeshAgent navMeshAgent;
    private int currentWaypointIndex;
    private Coroutine currentStateCoroutine;

    void Start()
    {
        currentState = State.Normal;
        currentWaypointIndex = 0;
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);

        StartCoroutine(FSM());
        Debug.Log(currentState);
    }

    IEnumerator FSM()
    {
        while (true)
        {
            yield return StartCoroutine(currentState.ToString());
        }
    }

    IEnumerator Normal()
    {
        while (currentState == State.Normal)
        {
            Patrol();
            yield return null;
        }
    }

    IEnumerator Investigate()
    {
        while (currentState == State.Investigate)
        {
            InvestigateLogic();
            yield return null;
        }
    }

    IEnumerator Wait()
    {
        float timer = secondsWaiting;
        while (currentState == State.Wait)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                ChangeState(State.Normal);
            }
            else
            {
                // Cambiar a la animación "looking"
                GetComponent<Animator>().Play("looking");
            }
            yield return null;
        }

        // Restaurar la animación original al salir del estado de espera
        GetComponent<Animator>().Play("walking");
    }

    IEnumerator Chase()
    {
        navMeshAgent.speed = chaseSpeed;
        while (currentState == State.Chase)
        {
            ChasePlayer();
            yield return null;
        }
    }

    void Patrol()
    {
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }

    void InvestigateLogic()
    {
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            ChangeState(State.Wait);
        }
    }

    private void OnEnable()
    {
        CameraDetection.OnPlayerDetected += HandlePlayerDetected;
    }

    private void OnDisable()
    {
        CameraDetection.OnPlayerDetected -= HandlePlayerDetected;
    }

    private void HandlePlayerDetected(Vector3 playerPosition)
    {
        ChangeState(State.Investigate);
        navMeshAgent.SetDestination(playerPosition);
    }

    void ChasePlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            navMeshAgent.SetDestination(player.transform.position);
        }
    }

    void ChangeState(State newState)
    {
        if (currentState == newState) return;

        currentState = newState;

        if (currentStateCoroutine != null)
        {
            StopCoroutine(currentStateCoroutine);
        }

        currentStateCoroutine = StartCoroutine(currentState.ToString());
    }

    void OnTriggerEnter(Collider other)
    {
        if (currentState != State.Chase && other.gameObject.tag == "Player")
        {
            ChangeState(State.Chase);
        }
    }    
}
