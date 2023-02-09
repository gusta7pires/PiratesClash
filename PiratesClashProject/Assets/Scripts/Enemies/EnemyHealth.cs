using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
     [SerializeField] private int maxLife = 5;
    private int currentLife;

    private bool alive = true;

    [SerializeField] private HealthBar healthBar;

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

    public void SetHealthBar(Canvas canvas){
        healthBar.transform.SetParent(canvas.transform);
    }

    public void LoseLife(){
        currentLife--;

        healthBar.SetProgress((float)currentLife / (float)maxLife);

        if(currentLife < 3){
            render.sprite = enemySprites[2];
        }else if (currentLife < 5){
            render.sprite = enemySprites[1];
        }

        if(currentLife <= 0){
            SessionManager.session.PlayerPoints++;
            Explode();
        }
    }

    public void Explode(){
        currentLife = 0;
        healthBar.SetProgress((float)currentLife / (float)maxLife);
        alive = false;
        render.sprite = enemySprites[3];
        ExplosionsCaller.instance.CallShipExplosion(this.gameObject);
        alive = false;
        GameManager.gm.EnemySpawnPos.EnemyDeath();
        Destroy(healthBar.gameObject, 1f);
        Destroy(this.gameObject, 1f);

    }
}
