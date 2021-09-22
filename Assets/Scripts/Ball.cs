using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    float startingPositionY;
    public float force=10f; //default
    string initPlayer;
    ScoreManager scoreL,scoreR;

    void Start(){
        scoreL = GameObject.Find("LeftTriggerScore").GetComponent<ScoreManager>();
        scoreR = GameObject.Find("LeftTriggerScore").GetComponent<ScoreManager>();
        initPlayer = "Player1";
        resetPos(initPlayer); //init
    }

    void Update(){
        if (this.gameObject.transform.position.y < -10f) resetPos(initPlayer);
    }

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.name == "Player1"){
            this.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.forward * force,collision.GetContact(0).point, ForceMode.Force);
            CameraShake camShake;
            camShake = GameObject.Find("Main Camera").GetComponent<CameraShake>();
            camShake.Shake(collision.transform.position);
        }

        if (collision.gameObject.name == "Player2" || collision.gameObject.name=="EnemyAI"){   
            this.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.back * force,collision.GetContact(0).point, ForceMode.Force);
            CameraShake camShake;
            camShake = GameObject.Find("Main Camera").GetComponent<CameraShake>();
            camShake.Shake(collision.transform.position);
        }

        if (collision.gameObject.name == "LeftTriggerScore"){

            if (GameObject.Find("Player2") != null){
                scoreR.setScore("Player2");
                initPlayer = "Player2";
            }

            if (GameObject.Find("EnemyAI") != null){
                scoreL.setScore("EnemyAI");
                initPlayer = "EnemyAI";
            }
        }

        if (collision.gameObject.name == "RightTriggerScore"){
            scoreL.setScore("Player1");
            initPlayer = "Player1";
        }
    }

    void OnCollisionStay(Collision collision){
        Vector3 tempos = this.transform.position*Time.deltaTime;

        if (Vector3.Distance(tempos, this.transform.position) < 1f) this.gameObject.GetComponent<Rigidbody>().AddExplosionForce(2f, this.transform.position, 1f);
    }

    public float getForce() {
        return force;
    }

    public void resetPos(string s){
        startingPositionY = 0.25f;

        if(s == "Player1") this.transform.position = new Vector3(GameObject.Find(s).transform.position.x, startingPositionY, GameObject.Find(s).transform.position.z + 0.5f);
        if (s == "Player2" || s == "EnemyAI") this.transform.position = new Vector3(GameObject.Find(s).transform.position.x, startingPositionY, GameObject.Find(s).transform.position.z - 0.5f);
    }

}
