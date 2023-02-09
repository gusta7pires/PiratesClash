using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SessionManager : MonoBehaviour
{
    public static SessionManager session;
    private void Awake(){
        if(session == null){
            session = this;
        }
    }

    private float sesionTime;
    private float timeValue;

    private int playerPoints;

    [SerializeField] private TMP_Text timeTxt;
    [SerializeField] private TMP_Text pointsTxt;
    [SerializeField] private GameObject gameOverPanel;
    

    private void Start(){
        sesionTime = GameManager.gm.GameSessionTime * 60;
        timeValue = sesionTime;
        playerPoints = 0;
    }

    private void Update(){
        if(!GameManager.gm.Player.GetComponent<PlayerHealth>().Alive){
            return;
        }

        if(timeValue > 0){
            timeValue -= Time.deltaTime;
        }
        else{
            timeValue = 0;
            GameOver();
        }
        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay){
        if(timeToDisplay<0){
            timeToDisplay = 0;
        }
        else if(timeToDisplay>0){
            timeToDisplay += 1;
        }


        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void GameOver(){
        GameManager.gm.Player.GetComponent<PlayerHealth>().Alive = false;
        string initialPointTxt = "Points: ";
        pointsTxt.text = initialPointTxt + playerPoints.ToString();
        gameOverPanel.SetActive(true);
    }

    public int PlayerPoints{
        get {return playerPoints;}
        set {playerPoints = value;}
    }
}
