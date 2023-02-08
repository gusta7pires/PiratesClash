using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxLife = 10;
    private int currentLife;
    private bool alive = true;
    public bool Alive{
        get {return alive;}
        set {alive = value;}
    }
    
    [SerializeField] private Sprite [] playerSprites;
    [SerializeField] private SpriteRenderer render;

    private void Start(){
        currentLife = maxLife;
        alive = true;
        render.sprite = playerSprites[0];
    }

    public void LoseLife(){
        if(!alive){
            return;
        }

        currentLife--;

        if(currentLife < 5){
            render.sprite = playerSprites[2];
        }else if(currentLife < 9){
            render.sprite = playerSprites[1];
        }

        if(currentLife <= 0){
            render.sprite = playerSprites[3];
            ExplosionsCaller.instance.CallExplosion(this.gameObject);
            alive = false;
            //Puxar tela de Game Over
            Debug.Log("MORREU");
        }
    }
}
