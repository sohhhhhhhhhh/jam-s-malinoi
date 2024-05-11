using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject pointPrefab;
    private Vector2 _delta;
    private Vector2 _spawnPosition;
    public int needEnemy;
    public float distance;
    private int _remainingEnemiesToSpawn;
    private int _prefabNumber;
    private GameObject _point;
    private bool flag;
    public int EnemyToThisRoom;

    private void Update()
    {
        if (transform.childCount == 0)
        {
            _remainingEnemiesToSpawn = needEnemy;
        }

        if ((_remainingEnemiesToSpawn != 0) && (EnemyToThisRoom > 0))
        {
            _prefabNumber = UnityEngine.Random.Range(0, 2);
            _remainingEnemiesToSpawn--;
            EnemyToThisRoom--;

            _delta = transform.position;
            _spawnPosition = Random.insideUnitCircle * distance + _delta;
            _point = Instantiate(pointPrefab, _spawnPosition, Quaternion.identity, transform) as GameObject;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        
        Destroy(_point);
        Instantiate(enemyPrefabs[_prefabNumber], _spawnPosition, Quaternion.identity, transform);
    }
}