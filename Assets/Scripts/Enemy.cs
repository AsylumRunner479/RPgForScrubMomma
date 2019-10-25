using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{   public enum AIState
    {

    }
    //gives a bunch of stats that enemies can use in their own scripts
    [Header("Base Stats")]
    public AIState state;
    public float curHealth, maxHealth, moveSpeed, attackRange, attackSpeed, sightRange;
    [Space(5)]
    [Header("Base References")]
    //allows you to insert waypoints into the enemy
    public Transform waypointParent;
    protected Transform[] waypoints;
    public NavMeshAgent agent;
    public GameObject healthCanvas;

    public void Patrol()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
