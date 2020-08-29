using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class sliderIGuess : MonoBehaviour{
    Rigidbody rb;
    private Sequence _sequence;
    public Button activateButton;
    public GameObject pins;
    public GameObject pinSpawnPos;

    private pinCounter pC;

    public bool canCount = true;
    
    private void Start(){
        rb = GetComponent<Rigidbody>();
        pC = GameObject.Find("pinCounter").GetComponent<pinCounter>();
    }

    private void Update(){
        if(_sequence != null) activateButton.interactable = !_sequence.IsPlaying();
    }

    public void replacePins(){
        //canCount = false;
        //pC.special.SetText("resetting...");
        //_sequence = DOTween.Sequence().SetAutoKill(false);
        //_sequence.Append(rb.DOMoveY(0.1f, 0.5f));
        //_sequence.Append(rb.DOMoveX(11.1f, 2f));
        //_sequence.Append(rb.DOMoveX(8.5f, 0.5f));
        //_sequence.Append(rb.DOMoveY(0.8f, 0.5f));
        //_sequence.OnComplete(makePins);
        //_sequence.Play();
    }

    public void lower()
    {
        rb.DOMoveY(0.1f, 0.5f);
    }

    public void rise()
    {
        rb.DOMoveY(0.8f, 0.5f);
    }

    public void makePins(){
        Instantiate(pins, pinSpawnPos.transform, false);
        pC.resetCount();
        //pC.special.SetText("reset!");
        canCount = true;
    }
}
