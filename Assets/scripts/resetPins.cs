using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetPins : MonoBehaviour
{
    Transform initialPosition;
    void Start(){
	initialPosition = transform;
    }
    
    public void resetPin(){
	transform.position = initialPosition.position;
	transform.rotation = initialPosition.rotation;
    }
}
