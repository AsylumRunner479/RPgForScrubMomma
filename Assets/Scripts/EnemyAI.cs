using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    public enum AIState
    {

    }
    // gives a bunch of stats for the enemy
    [Header("Base Stats")]
    public AIState state;
    public float curHealth, maxHealth, moveSpeed, attackRange, attackSpeed, sightRange;
    //allows you to desiginate the prefab
    public Transform waypointParent;
    private Transform[] points;
    public float waypointDistance;
    public float speed = 3f;
    public int currentWayPoint = 1;
    private NavMeshAgent agent;
    public GameObject healthCanvas;
    public Image healthBar;
    
    // Start is called before the first frame update
    private void Start()
    {
        //makes the enemy patrol at the start
        points = waypointParent.GetComponentsInChildren<Transform>();
        agent = GetComponent<NavMeshAgent>();
        //target = GameObject.FindGameObjectWithTag("Player").transform;
        Patrol();
    }

    // Update is called once per frame
    void Update()
    {
        Transform currentPoint = points[currentWayPoint];

        
        
    }
    //this make ths agent move from one waypoint to another
    public void Patrol()
    {
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[currentWayPoint].position;
        //transform.position = Vector3.MoveTowards(transform.position, points[currentWayPoint].position, 1f);
        if (transform.position.x == agent.destination.x && transform.position.z == agent.destination.z)
        {
            if(currentWayPoint < points.Length - 1)
            {
                currentWayPoint++;
            }
            else
            {
                //resets the waypoints to the begining
                currentWayPoint = 0;
            }
            
        }     
    }
}
   // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
      //  currentWayPoint = (currentWayPoint + 1) % points.Length;
        /*/if (points != null)
        {
            Gizmos.color = Color.red;
            for (int i = 1; i < points.Length - 1; i++)
            {
                Transform pointA = points[i];
                Transform pointB = points[i + 1];
                Gizmos.DrawLine(pointA.position, pointB.position);

            }
            for (int i = 1; i < points.Length; i++)
            {
                Gizmos.DrawSphere(points[i].position, waypointDistance);
            }
        }
        //Transform currentPoint = points[currentWaypoint];
        // Move towards current waypoint
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, 1f);
        // Check if distance between waypoint is close
        float distance = Vector3.Distance(transform.position, currentPoint.position);
        //if (distance < waypointDistance)
        //{
          //  currentWaypoint++;
        //}
        Vector3 direction = agent.path.corners[1] - transform.position;
        direction.Normalize();
        direction.x = Mathf.Round(direction.x);
        direction.y = Mathf.Round(direction.y);
        direction.z = Mathf.Round(direction.z);
        agent.Move(direction * 1f);
        /*/