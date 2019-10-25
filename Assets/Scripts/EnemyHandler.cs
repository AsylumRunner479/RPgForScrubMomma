﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyHandler : EnemyAI
{
    //desiginates who the player is
    public Transform target;

    public NavMeshAgent agent;
    //public Animator anim;
    //gives distances for how far away the player will be when they switch behaviour
    public float dist, sightDist;
    public GameObject self;
    //public GameObject projectilePrefab;
    //public Transform launchPoint;
    //public float fireRate, timeTillNextFire;
    public float turnSpeed;
    public float angle;
    public EnemyAI myAI;
    public Animator anim;
    //public float curHealth, maxHealth;
    void Start()
    {
        //sets the conditions at the start
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = self.GetComponent<NavMeshAgent>();
        myAI = self.GetComponent<EnemyAI>();
        anim = self.GetComponent<Animator>();
    }
    void Update()
    {
        //kills the enemy when they lose all their health
        if (curHealth <= 0)
        {
            anim.SetTrigger("Die");
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
                anim.SetTrigger("Bite Attack");
            }
            //follows the player when they see him
            else if (dist <= sightRange)
            {
                agent.destination = target.position;
                anim.SetBool("Walk", false);
                     anim.SetBool("Run", true);
                //agent.destination = transform.position;
                //Vector3 targetDir = target.position - transform.position;
                //Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, turnSpeed * Time.deltaTime, 0.0f);
                //transform.rotation = Quaternion.LookRotation(newDir);
                //Shoot();
            }
            

            else
            {
                anim.SetBool("Walk", true);
                anim.SetBool("Run", false);
                myAI.Patrol();
                //timeTillNextFire = 0;
            }
        }
    }
    /*/private void LateUpdate()
    {
        if(curHealth <= 0)
        {
            Destroy(this.gameObject, 0.5f);
        }
    }
    void Shoot ()
    {   if (PlayerHandler.isDead == false)
        {
            timeTillNextFire += Time.deltaTime;
            if (timeTillNextFire >= fireRate)
            {
                anim.SetTrigger("Attack");
                Invoke("Fire", 0.75f);
                timeTillNextFire = 0;
            }
        }
    }
    void Fire()
    {
        Transform clone = Instantiate(projectilePrefab, launchPoint.position, launchPoint.rotation).GetComponent<Transform>();
        clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * 75);

       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Sword")
        {
            curHealth -= 50;
        }
    }
    /*/
}
