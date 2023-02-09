using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float enemySpawnTime = 5f;
    private float spawnTimer;

    [SerializeField] private int maxEnemiesInMap = 10;
    private int numberOfEnemies = 0;

    [SerializeField] private GameObject [] enemies;
    [SerializeField] private Transform [] spawnPos;
    [SerializeField] private Canvas HealthBarCanvas;

    private void Start(){
        GameManager.gm.EnemySpawnPos = this;
        enemySpawnTime = GameManager.gm.EnemySpawnTime;
        spawnTimer = enemySpawnTime;
        for(int i = 0; i < enemies.Length; i++){
            int posIndex = Random.Range(0, spawnPos.Length);
            GameObject enemy = Instantiate(enemies[i], spawnPos[posIndex].position, spawnPos[posIndex].rotation);
            enemy.GetComponent<EnemyHealth>().SetHealthBar(HealthBarCanvas);
            numberOfEnemies ++;
        }
    }

    private void Update(){
        if(!GameManager.gm.Player.GetComponent<PlayerHealth>().Alive){
            return;
        }

        if(numberOfEnemies == maxEnemiesInMap)
            spawnTimer = Time.time + enemySpawnTime;

        if(spawnTimer < Time.time && numberOfEnemies <= maxEnemiesInMap){
            SpawnEnemy();
            spawnTimer = Time.time + enemySpawnTime;
        }
    }

    private void SpawnEnemy(){
        int enemyIndex = Random.Range(0, enemies.Length);
        int posIndex = Random.Range(0, spawnPos.Length);

        float playerDistance = Vector2.Distance(spawnPos[posIndex].transform.position, GameManager.gm.Player.transform.position);
        if(playerDistance < 18){
            bool otherSpawn = Random.Range(0, 2) == 0 ? true : false;
            if(otherSpawn){
                posIndex++;
                if(posIndex >= spawnPos.Length){
                    posIndex = 0;
                }
            }else{
                posIndex--;
                if(posIndex <= 0){
                    posIndex = spawnPos.Length - 1;
                }
            }
        }

        GameObject enemy = Instantiate(enemies[enemyIndex], spawnPos[posIndex].position, spawnPos[posIndex].rotation);
        enemy.GetComponent<EnemyHealth>().SetHealthBar(HealthBarCanvas);
        numberOfEnemies++;
    }

    public void EnemyDeath(){
        numberOfEnemies--;
    }
}
