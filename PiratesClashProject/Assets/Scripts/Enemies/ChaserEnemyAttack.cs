using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserEnemyAttack : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Player")){
            col.GetComponent<PlayerHealth>().LoseLife();
            GetComponent<EnemyHealth>().Explode();
            Destroy(this.gameObject, 1f);
        }
    }
}
