using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public Transform PuntoInicio;
    public GameObject player;
    private Animator anim;
    private CharacterController controller;

    public float speed = 600.0f;
    public float turnSpeed = 400.0f;
    private Vector3 moveDirection = Vector3.zero;
    public float gravity = 20.0f;

    void Start()
    {
        this.transform.position = PuntoInicio.position;
        controller = player.GetComponent<CharacterController>();
        anim = player.GetComponentInChildren<Animator>();
    }
    public void Reiniciar() { 
        this.transform.position = PuntoInicio.position;
    }

    void Update()
    {
        if (Input.GetKey("w"))
        {
            anim.SetInteger("AnimationPar", 1);
        }
        else
        {
            anim.SetInteger("AnimationPar", 0);
        }

        if (controller.isGrounded)
        {
            moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
        }

        float turn = Input.GetAxis("Horizontal");
        transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
        controller.Move(moveDirection * Time.deltaTime);
        moveDirection.y -= gravity * Time.deltaTime;
    }
}
