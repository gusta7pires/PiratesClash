using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
     [SerializeField] private int maxLife = 5;
    private int currentLife;

    private bool alive = true;

    public bool Alive{
        get {return alive;}
        set {alive = value;}
    }

    [SerializeField] private Sprite [] enemySprites;
    [SerializeField] private SpriteRenderer render;

    private void Start(){
        currentLife = maxLife;
        render.sprite = enemySprites[0];
    }

    public void LoseLife(){
        currentLife--;

        if(currentLife < 3){
            render.sprite = enemySprites[2];
        }else if (currentLife < 5){
            render.sprite = enemySprites[1];
        }

        if(currentLife <= 0){
            Explode();
        }
    }

    public void Explode(){
        alive = false;
        render.sprite = enemySprites[3];
        ExplosionsCaller.instance.CallExplosion(this.gameObject);
        alive = false;
        Destroy(this.gameObject, 1f);
    }
}
