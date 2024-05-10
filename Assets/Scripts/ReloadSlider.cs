using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadSlider : MonoBehaviour
{
    public Slider slider;

    public void SetMaxTime(float time) {
        slider.maxValue = time;
        slider.value = 0;
        
    }


    public void SetTime(float time) {
        slider.value = time;

    }

    public void SetEnable(bool IsActive) {
        slider.gameObject.SetActive(IsActive);
    }
}
