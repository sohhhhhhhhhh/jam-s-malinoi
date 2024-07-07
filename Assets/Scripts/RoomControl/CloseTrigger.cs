using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseTrigger : MonoBehaviour
{
    public static CloseTrigger Instance { get; private set; }
    public GameObject closeDoor;
    public bool spawnStart = false;
    
    void Awake()
    {
        Instance = this;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && !spawnStart) {
            closeDoor.SetActive(true);
            spawnStart = true;
        }
    }
}
