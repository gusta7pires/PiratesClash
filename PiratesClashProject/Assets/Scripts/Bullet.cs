using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 400f;

    private Rigidbody2D rb;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 3f);
    }
    
    void FixedUpdate()
    {
        rb.velocity = (Vector2)transform.up * speed * Time.fixedDeltaTime;
    }
}
