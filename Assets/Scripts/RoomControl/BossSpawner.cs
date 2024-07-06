using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public float timer;
    private float _spawnTime;
    public GameObject enemyPrefab;

    void Start()
    {
        _spawnTime = timer;
    }

    private void Update()
    {
        _spawnTime -= Time.deltaTime;
        if (_spawnTime < 0)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform);
            _spawnTime = timer;
        }
    }
}
