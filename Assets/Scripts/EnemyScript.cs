using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;

    int m_CurrentWaypointIndex;

    void Start()
    {
        m_CurrentWaypointIndex = 0; // Iniciar en el primer waypoint
        navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
    }

    void Update()
    {
        // Verificar si el agente ha llegado a su destino actual y no está en movimiento
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            // Cambiar al siguiente waypoint
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
    }
}
