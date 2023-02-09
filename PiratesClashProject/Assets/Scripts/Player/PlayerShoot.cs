using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float frontalShotCoolDown = 1f;
    private float nextFrontalShot = 0f;
    [SerializeField] private float sideShotCoolDown = 1.5f;
    private float nextLeftSideShot = 0f;
    private float nextRightSideShot = 0f;

    [SerializeField] private Transform frontalShootPos;
    [SerializeField] private Transform [] rightShootPos;
    [SerializeField] private Transform [] leftShootPos;

    
    void Update()
    {
        if(!GetComponent<PlayerHealth>().Alive){
            return;
        }

        GameObject newBullet;
        if(Input.GetButtonDown("Fire1") && Time.time > nextFrontalShot){
            newBullet = Instantiate(bullet, frontalShootPos.position, frontalShootPos.rotation);
            newBullet.GetComponent<Bullet>().Shooter(this.gameObject);
            nextFrontalShot = Time.time + frontalShotCoolDown;
        }

        if(Input.GetButtonDown("Fire2") && Time.time > nextLeftSideShot){
            for(int i = 0; i < leftShootPos.Length; i++){
                newBullet = Instantiate(bullet, leftShootPos[i].position, leftShootPos[i].rotation);
                newBullet.GetComponent<Bullet>().Shooter(this.gameObject);
            }
            nextLeftSideShot = Time.time + sideShotCoolDown;
        }

        if(Input.GetButtonDown("Fire3") && Time.time > nextRightSideShot){
            for(int i = 0; i < rightShootPos.Length; i++){
                newBullet = Instantiate(bullet, rightShootPos[i].position, rightShootPos[i].rotation);
                newBullet.GetComponent<Bullet>().Shooter(this.gameObject);
            }
            nextRightSideShot = Time.time + sideShotCoolDown;
        }
    }
}
