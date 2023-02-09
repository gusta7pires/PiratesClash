using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text pointsTxt;

    private void Start(){
        gameOverPanel.SetActive(false);
    }

    public void PlayAgainBtn(){
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }
    
    public void MainMenuBtn(){
        SceneManager.LoadScene("MainMenu");
    }
}
