using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform frontalShootPos;
    [SerializeField] private float canShotDistance = 8f;
    [SerializeField] private float shotCoolDown = 1.5f;
    private float shotTimer = 0f;

    void Update(){
        if(!GetComponent<EnemyHealth>().Alive){
            return;
        }

        Transform target = PlayerManager.instance.Player.transform;
        float playerDistance = Vector2.Distance(target.position, transform.position);

        if(playerDistance <= canShotDistance && Time.time > shotTimer){
            GameObject newBullet = Instantiate(bullet, frontalShootPos.position, frontalShootPos.rotation);
            newBullet.GetComponent<Bullet>().Shooter(this.gameObject);
            shotTimer = Time.time + shotCoolDown;
        }
    }
}
