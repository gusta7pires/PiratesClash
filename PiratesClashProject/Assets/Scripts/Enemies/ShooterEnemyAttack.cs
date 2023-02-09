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
    private Transform target;

    private void Start(){
        target = GameManager.gm.Player.transform;
    }

    void Update(){
        if(!GetComponent<EnemyHealth>().Alive || !target.GetComponent<PlayerHealth>().Alive){
            return;
        }

        float playerDistance = Vector2.Distance(target.position, transform.position);

        if(playerDistance <= canShotDistance && Time.time > shotTimer){
            GameObject newBullet = Instantiate(bullet, frontalShootPos.position, frontalShootPos.rotation);
            newBullet.GetComponent<Bullet>().Shooter(this.gameObject);
            shotTimer = Time.time + shotCoolDown;
        }
    }
}
