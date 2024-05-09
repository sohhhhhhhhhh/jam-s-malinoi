using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyAIArcher : MonoBehaviour {
    public GameObject player;
    public GameObject bullet;
    public float fireRate;
    private float timer;
    private bool canFire = true;

    
    void Start() {
        timer = fireRate;
    }

    void Update() {
        updateTimer();

        if (canFire) {
            Instantiate(bullet, transform.position, Quaternion.identity);
            canFire = false;
        }
    }

    void updateTimer() {
        if (!canFire) {
            timer -= 1 * Time.deltaTime;
            if (timer <= 0) {
                canFire = true;
                timer = fireRate;
            }
        }
    }
}
