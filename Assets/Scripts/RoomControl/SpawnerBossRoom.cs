using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBossRoom : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    
    private Vector2 _delta;
    private Vector2 _spawnPosition;
    public float distance;
    private float _timer;
    public BossBehaviour _BossBehaviour;
    private int _countToSpawn;
    
    void Start()
    {
        _timer = 7f;
    }

    // Update is called once per frame
    void Update()
    {
        _timer -= 1 * Time.deltaTime;
        if (_timer <= 0 && transform.childCount <= 4 && _BossBehaviour.hp > 0)
        {
            _timer = UnityEngine.Random.Range(8, 12);
            _countToSpawn = UnityEngine.Random.Range(1, 3);
            _delta = transform.position;
            _spawnPosition = Random.insideUnitCircle * distance + _delta;
            for (int i = 0; i < _countToSpawn; i++)
            {
                SpawnEnemy();
            }
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefabs[0], _spawnPosition, Quaternion.identity, transform);
    }
}
