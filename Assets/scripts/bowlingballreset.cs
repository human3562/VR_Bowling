using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowlingballreset : MonoBehaviour{

    public GameObject resetPos;
    
    public void resetPosition(){
	GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
	transform.position = resetPos.transform.position;
    }
}
