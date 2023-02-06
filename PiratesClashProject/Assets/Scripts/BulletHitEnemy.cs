using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHitEnemy : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Enemy")){
            Debug.Log("EXPLOOOXION!");
        }
    }
}
