using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class dropDown : MonoBehaviour
{
    public void drop()
    {
        transform.DORotate(new Vector3(0f,0f,20f), 1f).SetEase(Ease.OutBounce);
    }
}
