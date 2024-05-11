using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletScript : MonoBehaviour {
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public int damage;
    private EnemyStats ES;
    private BossBehaviour BS;
    public float speed;
    
    void Start() {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - Shooting.Instance.transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;
    }

    private void Update() {
       
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Enemy") {
            ES = col.gameObject.GetComponent<EnemyStats>();
            ES.getDamage(damage);
        }
        
        if (col.gameObject.tag == "Boss") {
            BS = col.gameObject.GetComponent<BossBehaviour>();
            BS.GetDamage(damage);
        }

        if (col.gameObject.tag != "Player" && col.gameObject.tag != "Bullet") {
            Destroy(gameObject);
        }
    }
}
