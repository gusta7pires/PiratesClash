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
        GameManager.gm.Player = this.gameObject;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        if(!GetComponent<PlayerHealth>().Alive){
            movement = Vector2.zero;
            return;
        }
        
        PlayerInputs();
    }

    private void FixedUpdate(){
        MoveFoward();
        Turn();
    }

    private void PlayerInputs(){
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
    }

    private void MoveFoward(){
        //rb.MovePosition(rb.position + ((Vector2)transform.up * movement.y * maxSpeed * Time.fixedDeltaTime));
        //Vector2 direction = ((Vector2)transform.up * movement.y);
        Vector2 force = movement * maxSpeed * Time.fixedDeltaTime;

        rb.AddForce(force);
    }

    private void Turn(){
        //float rotate = -movement.x * turnSpeed * Time.fixedDeltaTime;
        //rb.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, rotate));
        if(movement != Vector2.zero){
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, movement);
            targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.fixedDeltaTime);
            rb.MoveRotation(targetRotation);
        }
        else{
            rb.angularVelocity = 0f;
        }
    }

}
