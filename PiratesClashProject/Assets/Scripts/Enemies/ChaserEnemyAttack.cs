using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserEnemyAttack : MonoBehaviour
{
    private bool hitOnce = true;
    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Player") && hitOnce){
            hitOnce = false;
            col.GetComponent<PlayerHealth>().LoseLife();
            GetComponent<EnemyHealth>().Explode();
            Destroy(this.gameObject, 1f);
        }
    }
}
