using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIMelee : MonoBehaviour
{
    private float _enemySpeed = 4.0f;
    private Rigidbody2D rb;
    private Transform _transform;
    private NavMeshAgent _navMeshAgent;
    private Vector3 _startingPosition;
    private float _attackRange = 5.0f;
    private int _damage = 10;
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
        // _startingPosition = transform.position;
    }

    private void FixedUpdate()
    {
        Vector3 playerPosition = PlayerController.Instance.GetPositionForEnemy();
        _navMeshAgent.SetDestination(playerPosition);

        if (Physics.Raycast(transform.position, PlayerController.Instance.GetPositionForEnemy() - transform.position,
                _attackRange))
        {
            Attack();
        }
    }

    private void Attack()
    {
        PlayerController.Instance.getDamage(_damage);
    }
}