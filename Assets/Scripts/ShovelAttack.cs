using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class ShovelAttack : MonoBehaviour {
    [SerializeField] private Animator anim;
    [SerializeField] private float meleeSpeed;
    [SerializeField] private int meleeDamage;
    private EnemyStats ES;
    [SerializeField] private float attackTime;
    public bool isAttacking = false;

    float timeUntilMelee;
    void Start() { }

    void Update() {
        if (timeUntilMelee <= 0f) {
            if (Input.GetKey(KeyCode.Space)) {
                anim.SetTrigger("Attack");
                isAttacking = true;
                timeUntilMelee = meleeSpeed;
            }
        }
        else {
            if (timeUntilMelee <= meleeSpeed - attackTime){
                isAttacking = false;
            }
            timeUntilMelee -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (isAttacking) {
            if (other.tag == "Enemy")
            {
                ES = other.gameObject.GetComponent<EnemyStats>();
                ES.getDamage(meleeDamage);
            }
        }
    }

    public bool IsAttacking() {
        return isAttacking;
    }
}