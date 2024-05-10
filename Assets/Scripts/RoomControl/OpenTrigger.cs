using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTrigger : MonoBehaviour
{
    
    public GameObject openDoor;
    


    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            openDoor.SetActive(false);
        }
    }
    
    
}
