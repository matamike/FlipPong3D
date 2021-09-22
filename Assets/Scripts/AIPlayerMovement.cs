using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayerMovement : MonoBehaviour{
   
    public float enemySpeed;

    GameObject enemy, ball;
    Rigidbody enemyRB;
    Vector3 enemyStartingPosition, targetDirection;
    float ballDistance,angle;
    
    void Start(){
        enemy = GameObject.Find("EnemyAI");
        enemyRB = enemy.GetComponent<Rigidbody>(); 
        enemyStartingPosition = enemy.transform.position;
        enemySpeed = 4f;
        angle = 0f;
        targetDirection = Vector3.forward;

        if (enemy != null) ball = GameObject.Find("Ball");
    }

    void Update(){
        Debug.DrawLine(this.transform.position, ball.transform.position, Color.red, 1f, true);

        if (Vector3.Distance(enemy.transform.position, ball.transform.position) < 7f){

            ballDistance = Vector3.Distance(enemy.transform.position, ball.transform.position);
            angle = Vector3.SignedAngle(enemy.transform.position, ball.transform.position, Vector3.up);
            targetDirection = ball.transform.position - enemy.transform.position;

            //if (ballDistance < 6f){
                enemy.transform.position += (new Vector3(targetDirection.x, 0f, 0f) * enemySpeed * Time.deltaTime);
                if (ballDistance < 3f){
                    if(angle<0f) enemy.transform.eulerAngles = new Vector3(0f,Mathf.Lerp(180f,160f, 2f), 0f);
                    if(angle>0f) enemy.transform.eulerAngles = new Vector3(0f,Mathf.Lerp(180f, 200f, 2f), 0f);
                }

                if (ballDistance > 3f) enemy.transform.eulerAngles = new Vector3(0f,180f,0f);
            //}
        }

    }

    void OnCollisionEnter(Collision collision){
        if (collision.collider.gameObject.name == "Ball"){
            if (enemyRB != null){
                enemyRB.constraints = RigidbodyConstraints.FreezePositionX;
                enemyRB.constraints = RigidbodyConstraints.None;
                enemyRB.constraints = RigidbodyConstraints.FreezeRotation;
                enemyRB.constraints = RigidbodyConstraints.FreezePositionY;
                enemyRB.constraints = RigidbodyConstraints.FreezePositionZ;
            }
        }

    }
}
