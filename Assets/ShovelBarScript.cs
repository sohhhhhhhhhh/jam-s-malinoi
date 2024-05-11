using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShovelBarScript : MonoBehaviour
{
    public Slider slider;
    

    public void SetMaxTimer(float timer) {
        slider.maxValue = timer;
        slider.value = timer;
    }


    public void SetTimer(float timer) {
        slider.value = timer;

    }
}
