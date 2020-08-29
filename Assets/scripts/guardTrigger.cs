using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardTrigger : MonoBehaviour
{
    public pinManipulator pM;
    public bool ignore = false;
    private void OnTriggerEnter(Collider other)
    {
        if(!ignore && other.gameObject.tag == "Bowling Ball" && pM.canCount)
        {
            //pM.removeDeadPins();
            pM.triggerEnter();
        }
    }
}
