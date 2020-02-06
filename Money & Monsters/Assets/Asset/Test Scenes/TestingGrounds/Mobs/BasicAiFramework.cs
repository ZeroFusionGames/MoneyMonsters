using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(NavMeshAgent))]
public class BasicAiFramework : MonoBehaviour
{
    public enum State
    {
        PATROL,
        CHASE,
        ATTACK,
    }
    public State state;
    public NavMeshAgent agent;
    private bool alive;
    public AiType aiType;

    public GameObject target;
    public List<Transform> waypoints = new List<Transform>();
    public int waypointsInd;
    public Vector3 waypointOffset;
    public bool useCustomWaypoints = false;
    public bool goToRandomWaypoints = true;
    public Animator animator;


    void Start()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        
        agent.updatePosition = true;
        agent.updateRotation = true;
        if (!useCustomWaypoints)
        {
            foreach (Transform item in GameObject.FindGameObjectWithTag("Main Manager").GetComponent<WaypointManagement>().waypoints)
            {
                waypoints.Add(item);
            }
        }
        state = State.PATROL;
        alive = true;
        target = GameObject.FindGameObjectWithTag("Player");

        if(!animator)
        {
            animator = GetComponentInChildren<Animator>();
        }
        //start FSM (finite state machine)
        waypointsInd = Random.Range(0, waypoints.Count - 1);
        StartCoroutine("FSM");
    }

    IEnumerator FSM()
    {
        while (alive)
        {
            switch(state)
            {
                case State.PATROL:
                    Patrol();
                    break;
                case State.CHASE:
                    Chase();
                    break;
                case State.ATTACK:
                    Attack();
                    break;
            }
            yield return null;
        }
    }

    void Patrol()
    {


        Vector3 waypointPos = new Vector3(waypoints[waypointsInd].position.x + waypointOffset.x, waypoints[waypointsInd].position.y + waypointOffset.y, waypoints[waypointsInd].position.z + waypointOffset.z);
        agent.speed = aiType.patrolSpeed;
        
        if ((Vector3.Distance(this.transform.position, target.transform.position) < aiType.viewRadius) && (agent.pathStatus.ToString() != "PathPartial"))
        {
            animator.SetTrigger("Chase");
            state = State.CHASE;
        }
        else if (Vector3.Distance(this.transform.position, waypointPos) > 2 /*&& agent.pathStatus != NavMeshPathStatus.PathPartial && agent.pathStatus != NavMeshPathStatus.PathInvalid*/)
        {
            
            agent.SetDestination(waypointPos);

        }
        else if (Vector3.Distance(this.transform.position, waypointPos) <= 2)
        {
            if (!goToRandomWaypoints)
            {
                if (waypointsInd < waypoints.Count - 1)
                {
                    waypointsInd++;

                }
                else
                {
                    waypointsInd = 0;
                }
            }
            else
            {

                waypointsInd = Random.Range(0, waypoints.Count - 1);
            }
            
        }

        else
        {
            Debug.Log(this.gameObject);
            agent.SetDestination(Vector3.zero);
        }
    }

    void Chase()
    {
        agent.speed = aiType.chaseSpeed;
        agent.SetDestination(target.transform.position);
        //character.Move(agent.desiredVelocity);
        if (Vector3.Distance(this.transform.position, target.transform.position) < aiType.attackDistance)
        {
            animator.SetTrigger("Attack");
            state = State.ATTACK;
        }
        else if (Vector3.Distance(this.transform.position, target.transform.position) > aiType.viewRadius)
        {
            animator.SetTrigger("Patrol");
            state = State.PATROL;
        }
    }

    void Attack()
    {
        
        agent.speed = aiType.attackSpeed;
        if (Vector3.Distance(this.transform.position, target.transform.position) > aiType.attackDistance)
        {
            animator.SetTrigger("Chase");
            
            state = State.CHASE;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject == target)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 waypointPos = new Vector3(waypoints[waypointsInd].position.x + waypointOffset.x, waypoints[waypointsInd].position.y + waypointOffset.y, waypoints[waypointsInd].position.z + waypointOffset.z);
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(waypointPos, 1);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, aiType.viewRadius);
        
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 waypointPos = new Vector3(waypoints[waypointsInd].position.x + waypointOffset.x, waypoints[waypointsInd].position.y + waypointOffset.y, waypoints[waypointsInd].position.z + waypointOffset.z);
        Debug.Log(this.GetComponentInParent<Transform>().gameObject.ToString() + agent.pathStatus.ToString());
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(waypointPos, 1);
    }
}
