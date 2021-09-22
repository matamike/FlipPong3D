using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour{
    Vector3 camInitPos;

    void Start(){
        camInitPos = this.transform.position;
    }

    public void Shake(Vector3 dir){
        //NEEDS PROPER FIX
        Debug.Log("Shake"); 
        Vector3 p1 = new Vector3(Mathf.Lerp(camInitPos.x, camInitPos.x + dir.x, 1f),transform.position.y,transform.position.z);
        //transform.position = new Vector3(Mathf.Lerp(transform.position.x, camInitPos.x, 0.2f), transform.position.y, transform.position.z);
        Vector3 p2 = new Vector3(Mathf.Lerp(camInitPos.x - dir.x, camInitPos.x, 1f), transform.position.y, transform.position.z);
        
        transform.position = new Vector3(Mathf.Lerp(p1.x, p2.x, Time.deltaTime), transform.position.y, transform.position.z);

    }
}
