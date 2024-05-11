using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    
    // private static BossBehaviour Instance { get; private set; }
    
    private int _hp = 200;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void GetDamage(int damage)
    {
        _hp -= damage;
        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
