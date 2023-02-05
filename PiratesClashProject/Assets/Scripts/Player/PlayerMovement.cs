using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float turnSpeed = 100f;

    [SerializeField] private float collisorRadius = 0.1f;
    [SerializeField] private Transform frontColl;
    [SerializeField] private Transform backColl;

    private Vector2 movement;
    private Rigidbody2D rigidbody2D;

    public LayerMask groundLayers;

    private void Start(){
        rigidbody2D = GetComponent<Rigidbody2D>();
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

        CheckColliders();
    }

    private void MoveFoward(){
        rigidbody2D.MovePosition(rigidbody2D.position + (-(Vector2)transform.up * movement.y * maxSpeed * Time.fixedDeltaTime)); 
    }

    private void Turn(){
        float rotate = -movement.x * turnSpeed * Time.fixedDeltaTime;
        rigidbody2D.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, rotate));
    }

    private void CheckColliders(){
        Collider2D frontCollider = Physics2D.OverlapCircle(frontColl.position, collisorRadius, groundLayers);
        if (frontCollider!=null){
            movement.x = movement.x/100;
            movement.y = movement.y/100;
        }

        Collider2D backCollider = Physics2D.OverlapCircle(backColl.position, collisorRadius, groundLayers);
        if (backCollider!=null){
            movement.x = movement.x/100;
            movement.y = movement.y/100;
        }
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(frontColl.position.x, frontColl.position.y, 0f), collisorRadius);
        Gizmos.DrawWireSphere(new Vector3(backColl.position.x, backColl.position.y, 0f), collisorRadius);
    }

    
}
