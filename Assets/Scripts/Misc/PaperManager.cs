using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperManager : MonoBehaviour {
    public static PaperManager Instance { get; private set; }

    public Image currentPaperusImage;

    public int paperCounter = 0;
    public UnityEngine.Sprite[] PaperusImagesArray;

    private Color currentPaperusColor;

    void Awake() {
        Instance = this;
    }

    public void FadePaperusMap() {
        paperCounter++;
        currentPaperusColor = currentPaperusImage.color;

        if (paperCounter == 1) {
            currentPaperusColor.a = 1;
            currentPaperusImage.color = currentPaperusColor;
        }

        if (paperCounter > PaperusImagesArray.Length) {
            return;
        }
        else {
            currentPaperusImage.sprite = PaperusImagesArray[(paperCounter - 1) % PaperusImagesArray.Length];
        }
    }
}