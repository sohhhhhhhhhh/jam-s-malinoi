using System;
using UnityEngine;
using UnityEngine.AI;

public class BossBehaviour : MonoBehaviour
{
    private int _hp = 20;

    private float _timer;
    private float _speed = 2f;
    private float _changeDirectionCooldown = 2;
    private int _currentDirectionIndex = 0;
    private Rigidbody2D _rb;
    private Vector3[] _moveDirections =
    {
        Vector3.right, Vector3.up, Vector3.down, Vector3.left
    };

    private void Awake()
    {
        _timer = _changeDirectionCooldown;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _rb.velocity = _moveDirections[_currentDirectionIndex] * _speed;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        print(_timer);
        if (_timer < 0)
        {
            if (_currentDirectionIndex + 1 < 4)
            {
                _currentDirectionIndex += 1;
            }
            else
            {
                _currentDirectionIndex = 0;
            }
            _rb.velocity = _moveDirections[_currentDirectionIndex] * _speed;
            _timer = _changeDirectionCooldown;
        }
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
