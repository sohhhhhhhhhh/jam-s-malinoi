using System;
using UnityEngine;
using UnityEngine.AI;

public class BossBehaviour : MonoBehaviour
{
    private int _hp = 20;

    private float _timer;
    private float _speed;
    private float _changeDirectionCooldown = 2f;
    private int _currentDirectionIndex = 0;

    private Vector3[] _moveDirections =
    {
        Vector3.back, Vector3.right, Vector3.forward, Vector3.left
    };

    private void Awake()
    {
        _timer = _changeDirectionCooldown;
    }

    private void Start()
    {
        transform.Translate(_moveDirections[_currentDirectionIndex] * Time.deltaTime * _speed);
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
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
