using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinGroup : MonoBehaviour
{
    void Update()
    {
        if(transform.childCount == 0)
        {
            Destroy(gameObject);
        }
    }

    public void makePinsKinematic()
    {
        foreach(Rigidbody rb in transform.GetComponentsInChildren<Rigidbody>())
        {
            if(!rb.gameObject.GetComponent<pin>().fell) rb.isKinematic = true;
            else
            {
                rb.gameObject.transform.parent = null;
            }
        }
    }

    public void deletePins()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).parent = null;
        }
    }

    public void removeKinematic()
    {
        foreach (Rigidbody rb in transform.GetComponentsInChildren<Rigidbody>())
        {
            rb.isKinematic = false;
        }
    }

    public void straighten()
    {
        foreach (Transform t in GetComponentsInChildren<Transform>())
        {
            t.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
