using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float turnSpeed = 100f;

    private Vector2 movement;
    private Rigidbody2D rb;


    private void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        PlayerInputs();
    }

    private void FixedUpdate(){
        MoveFoward();
        Turn();
    }

    private void PlayerInputs(){
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void MoveFoward(){
        //rb.velocity = -(Vector2)transform.up * movement.y * maxSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + (-(Vector2)transform.up * movement.y * maxSpeed * Time.fixedDeltaTime)); 
    }

    private void Turn(){
        float rotate = -movement.x * turnSpeed * Time.fixedDeltaTime;
        rb.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, rotate));
    }
}
