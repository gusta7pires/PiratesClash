using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float frontalShotCoolDown = 1f;
    private float nextFrontalShot = 0f;
    [SerializeField] private float sideShotCoolDown = 1.5f;
    private float nextSideShot = 0f;

    [SerializeField] private Transform frontalShootPos;
    [SerializeField] private Transform [] rightShootPos;
    [SerializeField] private Transform [] leftShootPos;

    
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && Time.time > nextFrontalShot){
            Instantiate(bullet, frontalShootPos.position, frontalShootPos.rotation);
            nextFrontalShot = Time.time + frontalShotCoolDown;
        }

        if(Input.GetButtonDown("Fire2") && Time.time > nextSideShot){
            for(int i = 0; i < rightShootPos.Length; i++){
                Instantiate(bullet, rightShootPos[i].position, rightShootPos[i].rotation);
            }
            for(int i = 0; i < leftShootPos.Length; i++){
                Instantiate(bullet, leftShootPos[i].position, leftShootPos[i].rotation);
            }
            nextSideShot = Time.time + sideShotCoolDown;
        }
    }
}
