using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Shooting : MonoBehaviour {
    public int reloadTime;
    public static Shooting Instance { get; private set; }
    private Camera mainCam;
    private Vector3 mousePos;
    public Transform bulletTransform;
    public GameObject  bullet;
    public bool canFire = true;
    public float timer;
    public float timeBetweenFiring;
    public int ammo;
    private int currentAmmo;
    public float reloadTimer;
    public bool reload = false;
    private SpriteRenderer spriteRenderer;
    
    
    private void Awake() {
        Instance = this;
    }

    void Start() {
        reloadTimer = reloadTime;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        currentAmmo = ammo;
        spriteRenderer = bulletTransform.GetComponent<SpriteRenderer>();
    }

    void Update() {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (currentAmmo < ammo && Input.GetKeyDown(KeyCode.R)) {
            reload = true;
        }
        if (reload) {
            reloadTimer -= 1 * Time.deltaTime;
            if (reloadTimer <= 0) {
                reloadTimer = reloadTime;
                currentAmmo = ammo;
                end_reload();
            }
        }
        

        if (!canFire) {
            timer += 1 * Time.deltaTime;
            if (timer >= timeBetweenFiring) {
                timer = 0;
                canFire = true;
            }
            
        }

        

        if (Input.GetMouseButton(0) && canFire && !reload) {
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            canFire = false;
            currentAmmo--;
            if (currentAmmo <= 0) {
                start_reload();
            }
        }

        if (currentAmmo < ammo && Input.GetKeyDown(KeyCode.E)) {
            reload = true;
        }
    }

    private void start_reload() {
        reload = true;
        spriteRenderer.color = Color.red;
    }
    private void end_reload() {
        reload = false;
        spriteRenderer.color = Color.white;
    }
}