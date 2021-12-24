using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class Atacar : MonoBehaviour
{
    public Life life;
    public GameObject monster;
    public GameObject player;
    Animator anim;
    Transform positionPlayer;
    Transform transform;
    public float distanceAtack = 0.3f;
    float distance = 3.0f;
    NavMeshAgent myNavMeshAgent;
    bool isAttack = false;
    DateTime nextDamage;
    double damageAfterTime = 1.0f;
    // Start is called before the first frame update

    void Start()
    {
        nextDamage = DateTime.Now;
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        transform = this.GetComponent<Transform>();
        positionPlayer = player.GetComponent<Transform>();
        anim = monster.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, positionPlayer.position);
        //Debug.Log(distance);
        if (distance < distanceAtack)
        {
            isAttack = true;
            this.anim.SetBool("atacar", isAttack);
            myNavMeshAgent.SetDestination(positionPlayer.position);
        }
        else
        {
            isAttack = false;
            this.anim.SetBool("atacar", isAttack);
        }
        Golpear();

    }
    private void Golpear()
    {
        if (isAttack && nextDamage <= DateTime.Now)
        {

            life.RestarVida();
            nextDamage = DateTime.Now.AddSeconds(System.Convert.ToDouble(damageAfterTime));
        }
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Player")
        {
            Debug.Log("ingreso");
            this.anim.SetBool("atacar", true);
        }
        else
        {
            this.anim.SetBool("atacar", false);
        }
    }
    */

}
