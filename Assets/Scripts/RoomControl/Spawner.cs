using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float timeSpawn = 5f;
    private float _timer;
    public float distance = 3;
    private void Start()
    {
        _timer = timeSpawn;
    }
    
    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0 && CloseTrigger.Instance.spawnStart)
        {
            _timer = timeSpawn;
            Vector2 delta = transform.position;
            Instantiate(enemyPrefab, Random.insideUnitCircle * distance + delta, Quaternion.identity);
        }
    }
}
