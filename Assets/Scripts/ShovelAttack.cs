using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelAttack : MonoBehaviour {
    [SerializeField] private Animator anim;
    [SerializeField] private float meleeSpeed;
    [SerializeField] private int meleeDamage;
    private EnemyStats ES;

    float timeUntilMelee;
    void Start() { }

    void Update() {
        if (timeUntilMelee <= 0f) {
            if (Input.GetKey(KeyCode.Space)) {
                anim.SetTrigger("Attack");
                timeUntilMelee = meleeSpeed;
            }
        }
        else {
            timeUntilMelee -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enemy") {
            ES = other.gameObject.GetComponent<EnemyStats>();
            ES.getDamage(meleeDamage);
        }
    }
}