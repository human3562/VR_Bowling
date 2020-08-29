using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeTime : MonoBehaviour
{
    Slider slider;
    private void Start()
    {
        slider = GetComponent<Slider>();
    }
    public void changeTimeScale()
    {
        Time.timeScale = slider.value;
    }
}
