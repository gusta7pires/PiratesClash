using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 400f;

    private Rigidbody2D rb;

    private string shooter;

    public void Shooter(GameObject whoShoot){
        shooter = whoShoot.tag;
    }

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 3f);
    }
    
    void FixedUpdate()
    {
        rb.velocity = (Vector2)transform.up * speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Enemy") && shooter == "Player" && col.GetComponent<EnemyHealth>().Alive){
            col.GetComponent<EnemyHealth>().LoseLife();
            ExplosionsCaller.instance.CallBulletExplosion(this.transform);
            Destroy(this.gameObject);
        }
        else if (col.CompareTag("Player") && shooter == "Enemy" && col.GetComponent<PlayerHealth>().Alive){
            col.GetComponent<PlayerHealth>().LoseLife();
            ExplosionsCaller.instance.CallBulletExplosion(this.transform);
            Destroy(this.gameObject);
        }
    }
}
