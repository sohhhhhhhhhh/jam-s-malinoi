using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowelManager : MonoBehaviour {
    private BoxCollider2D showelCollider;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            Destroy(gameObject);
            PlayerController.Instance.isShovelGot = true;
        }
    }
}
