using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyStats : MonoBehaviour {
    public int hp;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void getDamage(int damage) {
        hp -= damage;
        if (hp <= 0) {
            Destroy(gameObject);
        }
    }
    
}
