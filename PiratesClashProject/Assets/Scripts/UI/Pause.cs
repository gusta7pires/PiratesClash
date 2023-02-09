using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    private bool GameIsPaused = false;

    void Start(){
        Resume();
    }

    void Update()
    {
        if(Input.GetButtonDown("Cancel") && GameManager.gm.Player.GetComponent<PlayerHealth>().Alive){
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                PauseGame();
            }
        }
    }

    private void PauseGame(){
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    private void Resume(){
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void ContinueBtn(){
        Resume();
    }
}
