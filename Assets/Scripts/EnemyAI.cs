﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace RPG.Player
{
    public class EnemyAI : MonoBehaviour
    {
        // this is a general EnemyAI which is inherited by both the wolf and the goblin.
        //desiginates who the player is
        public Transform target;
        public float curHealth, maxHealth, moveSpeed, attackRange, attackSpeed, noiseRange, sense;
        public NavMeshAgent agent;

        //gives distances for how far away the player will be when they switch behaviour
        public float dist, sightDist;
        public GameObject self;
        //public GameObject playerShadow;
        public float turnSpeed;
        public float angle;
        public Movement movement;
        public Transform waypointParent;
        protected Transform[] points;
        public float waypointDistance;
        protected int currentWayPoint = 1;

        void Start()
        {
            //sets the conditions at the start
            target = GameObject.FindGameObjectWithTag("Player").transform;
            agent = self.GetComponent<NavMeshAgent>();
            points = waypointParent.GetComponentsInChildren<Transform>();


        }

        public virtual void Die()
        {
            Destroy(self);
        }

        public virtual void Update()
        {
            // A
            noiseRange = movement.noise * sense;
            //kills the enemy when they lose all their health
            if (curHealth <= 0)
            {
                Die();
            }
            //moves the enemy when the player is alive
            if (PlayerHandler.isDead == false)
            {
                dist = Vector3.Distance(target.position, transform.position);

                if (curHealth == 0)
                {
                    return;
                }
                //attacks the player if they get too close
                else if (dist <= attackRange)
                {
                    Debug.Log("Attack");

                }
                //follows the player when they hear him
                else if (dist <= noiseRange)
                {
                    agent.destination = target.position;

                }


                else
                {
                    if (points == null)
                        return;

                    if (points.Length == 0)
                        return;

                    // Set the agent to go to the currently selected destination.
                    agent.destination = points[currentWayPoint].position;
                    transform.position = Vector3.MoveTowards(transform.position, points[currentWayPoint].position, 1f);
                    if (transform.position.x == agent.destination.x && transform.position.z == agent.destination.z)
                    {
                        if (currentWayPoint < points.Length - 1)
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

        }
    }
}
