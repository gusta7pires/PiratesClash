using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    private void Awake(){
        if(gm == null){
            gm = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    [SerializeField] private float gameSessionTime;
    public float GameSessionTime{
        get {return gameSessionTime;}
        set {gameSessionTime = value;}
    }
    [SerializeField] private float enemySpawnTime;
    public float EnemySpawnTime{
        get {return enemySpawnTime;}
        set {enemySpawnTime = value;}
    }

    public void SetGameSesionTime (float time){
        gameSessionTime = time;
    }

    public void SetEnemySpawnTime (float time){
        enemySpawnTime = time;
    }

    private GameObject player;
    public GameObject Player{
        get {return player;}
        set {player = value;}
    }

    private EnemySpawner enemySpawnPos;
    public EnemySpawner EnemySpawnPos{
        get {return enemySpawnPos;}
        set {enemySpawnPos = value;}
    }

}
