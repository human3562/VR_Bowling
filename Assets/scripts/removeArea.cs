using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Pin")
        {
            Destroy(other.gameObject);
        }
        if(other.tag == "Bowling Ball")
        {
            other.GetComponent<bowlingBall>().resetBall();
        }
    }
}
