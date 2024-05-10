using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour {
    private BoxCollider2D paperCollider;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            Destroy(gameObject);
        }
    }

    // private void FixedUpdate() {
    //     OnTriggerEnter2D(PlayerController.Instance.GetComponent<BoxCollider2D>());
    // }
}
