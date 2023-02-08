using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionsCaller : MonoBehaviour
{
    public static ExplosionsCaller instance;

    private void Awake(){
        if(instance == null)
            instance = this;
    }

    [SerializeField] private GameObject shipExplosion;
    [SerializeField] private GameObject bulletExplosion;

    public void CallExplosion(GameObject ship){
        GameObject newShipExplosion = Instantiate(shipExplosion, ship.transform.position, ship.transform.rotation);
        newShipExplosion.transform.parent = ship.transform;
        Destroy(newShipExplosion, 1f);
    }
}
