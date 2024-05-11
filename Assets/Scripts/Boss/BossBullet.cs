using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public Vector2 Direction;
    private Rigidbody2D rb;
    public float speed;
    public int damage;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Direction.normalized * speed;
    }
    void Update()
    {   
    }
    
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            PlayerController.Instance.getDamage(damage);
            
            // Destroy(gameObject);
        }
    
        if (col.gameObject.tag != "Boss" && col.gameObject.tag != "Bullet") {
            Destroy(gameObject);
        }
    }
}
