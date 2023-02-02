using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    [SerializeField] private Transform frontalShootPos;
    [SerializeField] private Transform rightShootPos;
    [SerializeField] private Transform leftShootPos;

    
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Instantiate(bullet, frontalShootPos.position, frontalShootPos.rotation);
        }
    }
}
