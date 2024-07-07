using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIMelee : MonoBehaviour
{
    private float _enemySpeed = 4.0f;
    private Rigidbody2D PlayerRb;
    private Rigidbody2D rb;
    private Transform _transform;
    private NavMeshAgent _navMeshAgent;
    private Vector3 _startingPosition;
    private float _attackRange = 5.0f;
    private int _damage = 5;
    [SerializeField] private float _attackReloadTime;
    [SerializeField] private float _attackReloadTimer;
    private bool _canAttack = true;
    private float _knockbackTime = 0.5f;
    private float _knockbackTimer = 0.5f;

    [SerializeField] private bool _IsKnockBacked = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
    }

    void Start()
    {
        _attackReloadTimer = _attackReloadTime;
    }

    private void FixedUpdate()
    {
        if (!PlayerController.Instance.isDead)
        {
            Vector3 playerPosition = PlayerController.Instance.GetPositionForEnemy();
            _navMeshAgent.SetDestination(playerPosition);
            if (_IsKnockBacked)
            {
                _knockbackTimer -= Time.fixedDeltaTime;
                if (_knockbackTimer <= 0f)
                {
                    _knockbackTimer = _knockbackTime;
                    _IsKnockBacked = false;
                }
            }

            _navMeshAgent.isStopped = _IsKnockBacked;

            if (!_canAttack) UpdateTimer();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            _IsKnockBacked = true;
            other.GetComponent<Rigidbody2D>().AddForce((other.transform.position - transform.position).normalized * 4f, ForceMode2D.Impulse);
            rb.AddForce((transform.position - other.transform.position).normalized * 4f, ForceMode2D.Impulse);
            
            if (_canAttack)
            {
                PlayerController.Instance.getDamage(_damage);
                _canAttack = false;
            }
            
        }
    }

    private void UpdateTimer() {
        _attackReloadTimer -= Time.fixedDeltaTime;
        if (_attackReloadTimer <= 0f) {
            _canAttack = true;
            _attackReloadTimer = _attackReloadTime;
        }
    }
    
}