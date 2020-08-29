using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starRotation : MonoBehaviour
{
    public float rotateSpeed = 1f;
    void Update()
    {
        transform.Rotate(new Vector3(Time.deltaTime * rotateSpeed, 0f, 0f));
    }
}
