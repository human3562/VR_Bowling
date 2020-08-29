using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using Valve.VR;
using Valve.VR.Extras;

public class sceneSwitch : MonoBehaviour
{
    private Sequence _sequence;
    public GameObject button;
    public GameObject player;
    GameObject ball;
    bool pressed = false;

    private void Start()
    {
        ball = GameObject.Find("bowlingBall");
    }
    public void switchScene()
    {
	if(!pressed){
		pressed = true;
        	_sequence = DOTween.Sequence();
		_sequence.Append(button.GetComponent<Image>().DOColor(new Color(1,1,1), 0.4f));
        	_sequence.Append(button.GetComponent<Image>().DOFade(0, 1f));
        	_sequence.Join(button.GetComponentInChildren<TextMeshProUGUI>().DOFade(0, 1f));
        	_sequence.Append(ball.transform.DOMoveX(44f, 3).SetEase(Ease.Linear));
        	_sequence.Join(ball.transform.DORotate(new Vector3(0, 0, -1000), 3).SetEase(Ease.Linear));
        	_sequence.AppendCallback(gotoScene);
        	_sequence.Play();
	}
    }
    void gotoScene()
    {
        Debug.Log("boo");
	Destroy(player);
        //SteamVR_LoadLevel.Begin("bowling");
        GetComponent<SteamVR_LoadLevel>().enabled = true;
    }
}
