using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    Rigidbody ballRb;
    public int scoreLeft, scoreRight;
    Text playerLeft, playerRight,winningText;
    Tracking tr;
    
    void Start(){
        tr = GameObject.Find("TrackingObject").GetComponent<Tracking>();
        ballRb = GameObject.Find("Ball").GetComponent<Rigidbody>();
        playerLeft = GameObject.Find("LeftPlayer").GetComponent<Text>();
        playerRight = GameObject.Find("RightPlayer").GetComponent<Text>();
        winningText = GameObject.Find("WinningText").GetComponent<Text>();
        scoreLeft = 0;
        scoreRight = 0;
        winningText.text="";
    }

    private void LateUpdate(){
        if(scoreLeft==5 || scoreRight == 5) Time.timeScale = 0.01f; // stop time //pause game.
    }

    public void setScore(string player){
        if (player == "Player1"){
            scoreLeft += 1;
            tr.SetPlayerScoreStatus(scoreLeft);
            playerLeft.text = "Player 1 Score: " + scoreLeft.ToString();

            if (scoreLeft == 5){
                tr.SetPlayerWinStatus(1);
                string s = "Player1 Wins";
                winningText.text=s;
            }
        }

        if(player=="Player2" || player == "EnemyAI"){
            scoreRight += 1;
            tr.SetAiScoreStatus(scoreRight);
            playerRight.text = "Player 2 Score: " + scoreRight.ToString();

            if (scoreRight == 5){
                tr.SetPlayerWinStatus(0);
                string s = "Player2 Wins";
                winningText.text=s;
            }
        }
    }
    
}
