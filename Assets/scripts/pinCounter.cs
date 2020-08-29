using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pinCounter : MonoBehaviour
{
    public int count = 0;
    public int countThisTurn = 0;
    public TMP_Text pinScore;
    //public TMP_Text special;
    private audioManager aM;
    private pinManipulator pM;

    public bool allFell = false;

    private void Start()
    {
        aM = GameObject.Find("AudioManager").GetComponent<audioManager>();
        pM = GameObject.Find("pinManipulator").GetComponent<pinManipulator>();
    }

    public void resetCount()
    {
        count = 0;
        resetText();
    }

    private void resetText()
    {
        pinScore.SetText(count + " Кегель");
        if (count >= 10)
        {
            //special.SetText("Strike!");
            aM.playStrike();
            //pM.resetPins();
            allFell = true;
        }
        //if (count == 9) special.SetText("So close...");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Pin" && other.gameObject.GetComponent<pin>().fell == false)
        {
            if (pM.canCount)
            {
                count++;
                countThisTurn++;
                //Debug.Log(count);
                resetText();
                other.gameObject.GetComponent<pin>().playSound();
                other.gameObject.GetComponent<pin>().fell = true;
            }
            
        }
    }
}
