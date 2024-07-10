using System;
using UnityEngine;
using UnityEngine.AI;

public class BossBehaviour : MonoBehaviour
{
    public int hp = 20;
    public BossBar bossBar;
    private float _timer;
    private float _speed = 2f;
    private float _changeDirectionCooldown = 3;
    private int _currentDirectionIndex = 0;
    private Rigidbody2D _rb;
    private Vector3[] _moveDirections =
    {
        Vector3.right, Vector3.up, Vector3.down, Vector3.right, Vector3.left, Vector3.down, Vector3.up, Vector3.left
    };

    private void Awake()
    {
        _timer = _changeDirectionCooldown;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        bossBar.SetMaxHealth(hp);
        _rb.velocity = _moveDirections[_currentDirectionIndex] * _speed;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer < 0)
        {
            if (_currentDirectionIndex + 1 < 8)
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
        hp -= damage;
        bossBar.SetHealth(hp);
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerController.Instance.getDamage(3);
        }
    }
}