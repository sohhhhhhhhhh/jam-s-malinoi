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
    private BossBehaviour BS;
    [SerializeField] private float attackTime;
    public ShovelBarScript shovelBar;

    float timeUntilMelee;

    void Start() {
        shovelBar.SetMaxTimer(meleeSpeed);
    }

    void Update() {
        shovelBar.SetTimer(meleeSpeed - timeUntilMelee);
        if (timeUntilMelee <= 0f) {
            if (Input.GetKey(KeyCode.Space) && PlayerController.Instance.isShovelGot) {
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
        
        if (other.gameObject.tag == "Boss") {
            BS = other.gameObject.GetComponent<BossBehaviour>();
            BS.GetDamage(meleeDamage);
        }

    }
}