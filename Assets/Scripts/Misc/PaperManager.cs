using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperManager : MonoBehaviour
{
    public static PaperManager Instance { get; private set; }

    public Image currentPaperusImage;
    public Image currentDiaryImage;
    public Image pressEnter;

    public int paperCounter = 0;

    public UnityEngine.Sprite[] PaperusImagesArray;
    public UnityEngine.Sprite[] DiaryImagesArray;

    private Color currentPaperusColor;
    private Color currentDiaryColor;

    void Awake()
    {
        Instance = this;
    }

    public void FadePaperusMap()
    {
        paperCounter++;
        currentPaperusColor = currentPaperusImage.color;

        if (paperCounter == 1)
        {
            currentPaperusColor.a = 1;
            currentPaperusImage.color = currentPaperusColor;
        }

        if (paperCounter > PaperusImagesArray.Length)
        {
            return;
        }
        else
        {
            currentPaperusImage.sprite = PaperusImagesArray[(paperCounter - 1) % PaperusImagesArray.Length];
        }

        ShowCurrentDiaryImage();
    }

    public void ShowCurrentDiaryImage()
    {
        currentDiaryImage.sprite = DiaryImagesArray[(paperCounter - 1) % DiaryImagesArray.Length];
        currentDiaryColor = currentDiaryImage.color;
        currentDiaryColor.a = 255;

        currentDiaryImage.color = currentDiaryColor;
        pressEnter.color = currentDiaryColor;

    }

    public void HideDiaryImage()
    {
        currentDiaryColor = currentDiaryImage.color;
        currentDiaryColor.a = 0;
        currentDiaryImage.color = currentDiaryColor;
        pressEnter.color = currentDiaryColor;
    }
}