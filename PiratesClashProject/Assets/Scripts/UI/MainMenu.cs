using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject controlsPanel;

    [SerializeField] private TMP_Text SesionTimeTxt;
    [SerializeField] private TMP_Text SpawnTimeTxt;

    void Start(){
        GoBackMainMenu();
        SesionTimeTxt.text = GameManager.gm.GameSessionTime.ToString();
        SpawnTimeTxt.text = GameManager.gm.EnemySpawnTime.ToString();
    }

    public void PlayBtn(){
        SceneManager.LoadScene("SampleScene");
    }

    public void OptionsBtn(){
        mainPanel.SetActive(false);
        optionsPanel.SetActive(true);
        controlsPanel.SetActive(false);
    }

    public void ControlsBtn(){
        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);
        controlsPanel.SetActive(true);
    }

    public void GoBackMainMenu(){
        mainPanel.SetActive(true);
        optionsPanel.SetActive(false);
        controlsPanel.SetActive(false);
    }

    public void IncreaseSesionTime(){
        if(GameManager.gm.GameSessionTime < 3){
            GameManager.gm.GameSessionTime++;
            SesionTimeTxt.text = GameManager.gm.GameSessionTime.ToString();
        }
    }

    public void DecreaseSesionTime(){
        if(GameManager.gm.GameSessionTime > 1){
            GameManager.gm.GameSessionTime--;
            SesionTimeTxt.text = GameManager.gm.GameSessionTime.ToString();
        }
    }

    public void IncreaseSpawnTime(){
        if(GameManager.gm.EnemySpawnTime < 10){
            GameManager.gm.EnemySpawnTime++;
            SpawnTimeTxt.text = GameManager.gm.EnemySpawnTime.ToString();
        }
    }

    public void DecreaseSpawnTime(){
        if(GameManager.gm.EnemySpawnTime > 1){
            GameManager.gm.EnemySpawnTime--;
            SpawnTimeTxt.text = GameManager.gm.EnemySpawnTime.ToString();
        }
    }
}
