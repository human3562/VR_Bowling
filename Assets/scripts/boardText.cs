using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class boardText : MonoBehaviour
{ 
    void Update()
    {
        GetComponent<TextMeshPro>().SetText("FPS: "+1.0f/Time.deltaTime + "\n lookin good");
    }
}
