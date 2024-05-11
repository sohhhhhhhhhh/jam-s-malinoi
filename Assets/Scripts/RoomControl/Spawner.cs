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
    private GameObject _enemy;
    public GameObject paper;
    public int EnemyToThisRoom;
    public CloseTrigger ct;
    private bool _spawn = true;
    public GameObject door;

    private void Update()
    {
        if (transform.childCount == 0)
        {
            _remainingEnemiesToSpawn = needEnemy;
        }

        if ((_remainingEnemiesToSpawn != 0) && (EnemyToThisRoom > 0) && ct.spawnStart)
        {
            _prefabNumber = UnityEngine.Random.Range(0, enemyPrefabs.Length);
            _remainingEnemiesToSpawn--;
            EnemyToThisRoom--;

            _delta = transform.position;
            _spawnPosition = Random.insideUnitCircle * distance + _delta;
            _point = Instantiate(pointPrefab, _spawnPosition, Quaternion.identity, transform) as GameObject;
            SpawnEnemy();
        }

        if (EnemyToThisRoom == 0 && transform.childCount == 0 && _spawn)
        {
            _spawn = false;
            Instantiate(paper, PlayerController.Instance.GetPlayerPosition(), Quaternion.identity);
            door.SetActive(false);
        }
    }

    void SpawnEnemy()
    {
        Destroy(_point);
        Instantiate(enemyPrefabs[_prefabNumber], _spawnPosition, Quaternion.identity, transform);
    }
}