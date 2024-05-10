using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paper : MonoBehaviour {
    private BoxCollider2D paperCollider;

    

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            Destroy(gameObject);
            PaperManager.Instance.FadePaperusMap();
        }
    }

    
    
}