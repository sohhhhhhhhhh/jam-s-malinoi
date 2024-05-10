using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoText : MonoBehaviour
{
    public Shooting player;
    private int maxAmmo;
    private int currentAmmo_;
    [SerializeField] private Text ammoText_;


    void Start()
    {
        maxAmmo = player.GetMaxAmmo();
    }

    void Update()
    {
        currentAmmo_ = player.GetCurrentAmmo();
        ammoText_.text = string.Format("ammo: {0}/{1}", currentAmmo_, maxAmmo);
    }
}