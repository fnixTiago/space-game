using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Atacar : MonoBehaviour
{
    public GameObject monster;
    public GameObject player;
    Animator anim;
    Transform positionPlayer;
    Transform transform;
    public float distanceAtack = 0.3f;
    float distance = 3.0f;
    NavMeshAgent myNavMeshAgent;
    // Start is called before the first frame update

    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        transform = this.GetComponent<Transform>();
        positionPlayer = player.GetComponent<Transform>();
        anim = monster.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, positionPlayer.position);
        Debug.Log(distance);
        if (distance < distanceAtack)
        {
            this.anim.SetBool("atacar", true);
            myNavMeshAgent.SetDestination(positionPlayer.position);
        }
        else
        {
            this.anim.SetBool("atacar", false);
        }

    }
    private void OnCollisionEnter(Collision collision)
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


}
