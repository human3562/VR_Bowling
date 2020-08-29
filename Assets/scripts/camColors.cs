using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class camColors : MonoBehaviour{

    public Gradient colors;
    [Range(0f,1f)]
    public float speed = 0.5f;

    void Update(){
        Color current = colors.Evaluate((Time.time * speed) % 1f);
        RenderSettings.ambientSkyColor = current;
        GetComponent<Camera>().backgroundColor = current;
    }
}
