using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   GameObject playerOne, playerTwo;
   Rigidbody plRb1, plRb2;
   public  float playerSpeed;

    // Start is called before the first frame update
    void Start(){
        playerSpeed = 6f;

        playerOne = GameObject.Find("Player1");
        if (playerOne!=null)
            plRb1 = playerOne.GetComponent<Rigidbody>();

        playerTwo = GameObject.Find("Player2");
        if(playerTwo!=null)
            plRb2 = playerTwo.GetComponent<Rigidbody>();
    }

    void Update(){
        //player1
        if (playerOne != null){
            if (Input.GetKey(KeyCode.A)) {
                playerOne.transform.eulerAngles = new Vector3(0f, Mathf.LerpAngle(0f, 15f, 2f), 0f);
            }
            if (Input.GetKeyUp(KeyCode.A)) {
                playerOne.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }

            if (Input.GetKey(KeyCode.D)) {
                playerOne.transform.eulerAngles = new Vector3(0f, Mathf.LerpAngle(0f, 345f, 2f), 0f);
            }
            if (Input.GetKeyUp(KeyCode.D)) {
                playerOne.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }

            if (Input.GetKey(KeyCode.W)) {
                playerOne.transform.position += (Vector3.left * playerSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.S)) {
                playerOne.transform.position += (Vector3.right * playerSpeed * Time.deltaTime);
            }
        }

        //player2
        if (playerTwo != null)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                playerTwo.transform.position += (Vector3.left * playerSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                playerTwo.transform.position += (Vector3.right * playerSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                playerTwo.transform.eulerAngles = new Vector3(0f, Mathf.LerpAngle(0f, 15f, 2f), 0f);
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                playerTwo.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                playerTwo.transform.eulerAngles = new Vector3(0f, Mathf.LerpAngle(0f, 345f, 2f), 0f);
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                playerTwo.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.name == "Ball"){
            if (plRb1 != null)
            {
                plRb1.constraints = RigidbodyConstraints.FreezePositionX;
                plRb1.constraints = RigidbodyConstraints.None;
                plRb1.constraints = RigidbodyConstraints.FreezeRotation;
                plRb1.constraints = RigidbodyConstraints.FreezePositionY;
                plRb1.constraints = RigidbodyConstraints.FreezePositionZ;
            }
            if (plRb2 != null)
            {
                plRb2.constraints = RigidbodyConstraints.FreezePositionX;
                plRb2.constraints = RigidbodyConstraints.None;
                plRb2.constraints = RigidbodyConstraints.FreezeRotation;
                plRb2.constraints = RigidbodyConstraints.FreezePositionY;
                plRb2.constraints = RigidbodyConstraints.FreezePositionZ;
            }
        }
    }


}
