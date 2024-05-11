using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject pointPrefab;
    private Vector2 delta;
    private Vector2 spawnPosition;

    public float timeSpawn;
    private float _timer;
    public float distance;
    public int remainingEnemiesToSpawn;
    private int prefabNumber;
    private GameObject point;
    
    private void Start()
    {
        _timer = timeSpawn;
    }
    
    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0 && CloseTrigger.Instance.spawnStart && transform.childCount < 5 && remainingEnemiesToSpawn > 0)
        {
            prefabNumber = UnityEngine.Random.Range(0, 2);
            remainingEnemiesToSpawn--;
            _timer = timeSpawn;
            delta = transform.position;
            spawnPosition = Random.insideUnitCircle * distance + delta;
            point = Instantiate(enemyPrefabs[prefabNumber], spawnPosition, Quaternion.identity) as GameObject;
            Invoke("Spawn", 3f);
        }
    }

    private void Spawn()
    {
        point = enemyPrefabs[prefabNumber];
    }
}
