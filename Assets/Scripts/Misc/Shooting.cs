using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class Shooting : MonoBehaviour {
    public static Shooting Instance { get; private set; }
    
    private Camera mainCamera;
    private Vector3 mousePosition;
    public Transform bulletTransform;
    public GameObject  bullet;
    private SpriteRenderer spriteRenderer;

    public int currentAmmo;
    public float reloadTimer;
    [SerializeField] private int reloadTime;
    public float timer;
    public float timeBetweenFiring;
    public int ammo = 7;
    public ReloadSlider slider;
    
    public bool reload = false;
    public bool canFire = true;
    
    private void Awake() {
        Instance = this;
    }

    void Start() {
        reloadTimer = reloadTime;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        currentAmmo = ammo;
        spriteRenderer = bulletTransform.GetComponent<SpriteRenderer>();
        slider.SetMaxTime(reloadTime);
    }

    void Update() {
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePosition - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        if (rotZ > 90 || rotZ < -90) {
            gameObject.transform.GetChild(0).localScale = new Vector3(8, -8, 8);
        }
        else {
            gameObject.transform.GetChild(0).localScale = new Vector3(8, 8, 8);
        }

        if (currentAmmo < ammo && Input.GetKeyDown(KeyCode.R)) {
            start_reload();
        }
        if (reload) {
            slider.SetEnable(true);
            reloadTimer -= 1 * Time.deltaTime;
            slider.SetTime(reloadTime-reloadTimer);
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
            Instantiate(bullet, bulletTransform.position+transform.rotation.normalized*(new Vector3(0.6f, 0, 0)), transform.rotation);
            canFire = false;
            currentAmmo--;
            if (currentAmmo <= 0) {
                start_reload();
            }
        }
        
    }

    private void start_reload() {
        reload = true;
        spriteRenderer.color = Color.red;
    }
    private void end_reload() {
        reload = false;
        spriteRenderer.color = Color.white;
        slider.SetEnable(false);
    }

    public int GetCurrentAmmo() {
        return currentAmmo;
    }

    public int GetMaxAmmo() {
        return ammo;
    }
}