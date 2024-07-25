using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class pinManipulator : MonoBehaviour
{
    public Rigidbody pinGuard;
    public GameObject pinSpawner;
    public GameObject pinPrefab;
    public GameObject pinSpawnPos;
    public guardTrigger gT;
    public pinCounter pC;

    public scoreManager sM;

    private Sequence _sequence;
    public bool canCount = true;

    public void removeDeadPins()
    {
        _sequence = DOTween.Sequence();
        //_sequence.Append(pinGuard.DOMoveY(0.1f, 0.5f));
        _sequence.Append(pinGuard.DORotate(new Vector3(0,0,0), 0.5f));
        //_sequence.AppendInterval(1f);
        _sequence.AppendCallback(dontCount);

        _sequence.Append(pinSpawner.transform.DOMoveY(0.4f, 0.5f));
        _sequence.AppendCallback(pinSpawnPos.GetComponent<makeKinematic>().makePinsKinematic);
        _sequence.AppendCallback(pinSpawnPos.GetComponent<makeKinematic>().straightenPins);

        _sequence.Append(pinSpawnPos.transform.DOMoveY(0.7f, 0.5f));
        _sequence.Join(pinSpawner.transform.DOMoveY(1f, 0.5f));

        _sequence.Append(pinGuard.DOMoveX(11.1f, 2f));
        _sequence.Append(pinGuard.DOMoveX(9.2f, 0.5f));

        _sequence.Append(pinSpawnPos.transform.DOMoveY(-0.5f, 0.5f));
        _sequence.Join(pinSpawner.transform.DOMoveY(0.5f, 0.5f));

        _sequence.AppendCallback(pinSpawnPos.GetComponent<makeKinematic>().removePinsKinematic);
        _sequence.Append(pinSpawner.transform.DOMoveY(1f, 0.5f));

        //_sequence.Append(pinGuard.DOMoveY(0.8f, 0.5f));
        _sequence.AppendCallback(count);
        _sequence.Append(pinGuard.DORotate(new Vector3(0, 0, -60), 0.5f));

        _sequence.Play();
    }

    public void resetPins()
    {
        //pC.pinScore.SetText("0 Кегель");
        _sequence = DOTween.Sequence();
        //_sequence.Append(pinGuard.DOMoveY(0.1f, 0.5f));
        _sequence.Append(pinGuard.DORotate(new Vector3(0, 0, 0), 0.5f));

        //_sequence.AppendCallback(pinSpawnPos.GetComponent<makeKinematic>().makePinsKinematic);
        _sequence.AppendCallback(pinSpawnPos.GetComponent<makeKinematic>().removePins);
        canCount = false;
        
        _sequence.Append(pinGuard.DOMoveX(11.1f, 2f));
        _sequence.Append(pinGuard.DOMoveX(9.2f, 0.5f));
        
        _sequence.Append(pinSpawnPos.transform.DOMoveY(0.7f, 0.1f));
        _sequence.AppendCallback(makePins);
        _sequence.AppendCallback(pinSpawnPos.GetComponent<makeKinematic>().makePinsKinematic);
        //_sequence.Append(pinSpawner.transform.DOMoveY(0.4f, 0.5f));

        //_sequence.Join(pinSpawner.transform.DOMoveY(1f, 0.5f));


        _sequence.Append(pinSpawnPos.transform.DOMoveY(-0.5f, 1.0f));
        _sequence.Join(pinSpawner.transform.DOMoveY(0.5f, 1.0f));

        _sequence.AppendCallback(pinSpawnPos.GetComponent<makeKinematic>().removePinsKinematic);
        _sequence.Append(pinSpawner.transform.DOMoveY(1f, 0.5f));

        //_sequence.Append(pinGuard.DOMoveY(0.8f, 0.5f));
        _sequence.AppendCallback(count);
        _sequence.Append(pinGuard.DORotate(new Vector3(0, 0, -60), 0.5f));

        _sequence.Play();

    }


    public void triggerEnter()
    {
        if (canCount)
        {
	    gT.ignore = true;
            _sequence = DOTween.Sequence();
            //_sequence.Append(pinGuard.DOMoveY(0.1f, 0.5f));
            _sequence.Append(pinGuard.DORotate(new Vector3(0, 0, 0), 0.5f));
            _sequence.AppendInterval(4f);
            _sequence.AppendCallback(dontCount);
            _sequence.AppendCallback(ass);
            _sequence.Play();
        }
    }

    void ass()
    {
        sM.addToScore(pC.countThisTurn);
        pC.countThisTurn = 0;
        if (pC.allFell || sM.turn > 1)
        {
            sM.turn = 0;
            pC.allFell = false;
            resetPins();
        }
        else
        {
            removeDeadPins();
        }
    }

    public void makePins()
    {
        Instantiate(pinPrefab, pinSpawnPos.transform, false);
        pC.resetCount();
        //pC.special.SetText("reset!");
        //canCount = true;
    }

    void count()
    {
        canCount = true;
        gT.ignore = false;
    }

    void dontCount()
    {
        canCount = false;
    }
}
