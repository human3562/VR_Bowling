using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class bowlingBall : MonoBehaviour
{
    public GameObject respawnPoint;
    //private GameObject lane;
    public Transform frictionStart;
    public Transform frictionEnd;

    private AudioSource roll;
    private AudioSource hit;
    private Rigidbody rb;

    public AudioClip rolling;
    [Range(0f,1f)]
    public float rollingVolume;

    public AudioClip impact;
    [Range(0f, 1f)]
    public float impactVolume;

    public float defaultSpeed = 1;
    public float defaultPitch = 1;
    private float currentSpeed;

    bool onLane = false;

    void Start()
    {
        //lane = GameObject.Find("Lane");
        roll = gameObject.AddComponent<AudioSource>();
        roll.clip = rolling;
        roll.volume = rollingVolume;
        roll.spatialBlend = 1;

        hit = gameObject.AddComponent<AudioSource>();
        hit.clip = impact;
        hit.volume = impactVolume;
        hit.spatialBlend = 1;

        rb = GetComponent<Rigidbody>();
        //rb.AddForce(new Vector3(30000f, 0f, 0f));
        //Time.timeScale = 0.1f;
    }

    private void FixedUpdate()
    {
        float position = transform.position.x;
        float p = position - frictionStart.position.x;
        float d = frictionEnd.position.x - frictionStart.position.x;
        float t = p / d;
        if (t < 0.01f) t = 0.01f;
        if (t > 1) t = 1;
        SphereCollider mc = GetComponent<SphereCollider>();
        mc.material.dynamicFriction = t;
        mc.material.staticFriction = t;
        //Debug.Log(mc.material.dynamicFriction);
    }

    void Update()
    {
        if (transform.position.y < -2) resetBall();
        currentSpeed = rb.velocity.magnitude;
        if (onLane) {
            roll.pitch = defaultPitch * (currentSpeed / defaultSpeed);
            if (rb.velocity.magnitude > 0.01)
            {
                if (!roll.clip == rolling) roll.clip = rolling;
                if (!roll.isPlaying)
                {
                    roll.Play();
                }
            }
            else
            {
                roll.Stop();
            }
        }
        else
        {
            roll.Stop();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Lane")
        {
            onLane = true;
            hit.volume = rb.velocity.magnitude / 5;
            if (hit.volume < 0) hit.volume = 0;
            if (hit.volume > 1) hit.volume = 1;
            hit.Play();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Lane")
        {
            onLane = false;
        }
    }

    public void resetBall()
    {
        rb.angularVelocity = new Vector3(0, 0, 0);
        rb.velocity = new Vector3(-5f, 0, 0);
        transform.position = respawnPoint.transform.position;
    }

}
