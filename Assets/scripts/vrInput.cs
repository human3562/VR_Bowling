/* SceneHandler.cs*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;

public class vrInput: MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;
    public Button dummy;
    //bool pressed = false;

    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Cube")
        {
            Debug.Log("Cube was clicked");
        } else if (e.target.name == "startBtn")
        {
            Debug.Log("Button was clicked");
	    //if(pressed == false)
	    	e.target.gameObject.GetComponent<Button>().onClick.Invoke();
	    //pressed = true;
        }
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Cube")
        {
            Debug.Log("Cube was entered");
        }
        else if (e.target.name == "startBtn")
        {
            Debug.Log("Button was entered");
	    e.target.gameObject.GetComponent<Button>().Select();
	    
        }
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Cube")
        {
            Debug.Log("Cube was exited");
        }
        else if (e.target.name == "startBtn")
        {
            Debug.Log("Button was exited");
	    //e.target.gameObject.GetComponent<Button>().Deselect();
	    dummy.Select();
        }
    }
}