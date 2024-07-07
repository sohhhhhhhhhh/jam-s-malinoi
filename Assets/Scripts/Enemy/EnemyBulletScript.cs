using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour {
    private Vector3 playerPos;
    private Rigidbody2D rb;
    public int damage;
    public float speed;
    private PlayerController PC;
    void Start() {
        
        rb = GetComponent<Rigidbody2D>();
        Vector2 direction = PlayerController.Instance.GetPlayerPosition() - new Vector2(transform.position.x, transform.position.y);
        rb.velocity = direction.normalized * speed;

    }

    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            PlayerController.Instance.getDamage(damage);
            // Destroy(gameObject);
        }

        if (col.gameObject.tag != "Enemy" && col.gameObject.tag != "Bullet") {
            Destroy(gameObject);
            

        }
    }
}
