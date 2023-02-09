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
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private Canvas HealthBarCanvas;

    private void Start(){
        currentLife = maxLife;
        alive = true;
        render.sprite = playerSprites[0];
        SetHealthBar(HealthBarCanvas);
    }

    public void SetHealthBar(Canvas canvas){
        healthBar.transform.SetParent(canvas.transform);
    }

    public void LoseLife(){
        if(!alive){
            return;
        }

        currentLife--;

        healthBar.SetProgress((float)currentLife / (float)maxLife);

        if(currentLife < 5){
            render.sprite = playerSprites[2];
        }else if(currentLife < 9){
            render.sprite = playerSprites[1];
        }

        if(currentLife <= 0){
            render.sprite = playerSprites[3];
            ExplosionsCaller.instance.CallShipExplosion(this.gameObject);
            alive = false;
            SessionManager.session.GameOver();
        }
    }
}
