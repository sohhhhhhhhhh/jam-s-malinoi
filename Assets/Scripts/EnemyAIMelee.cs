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
        // EnemyMovement();
        Vector3 playerPosition = PlayerController.Instance.GetPositionForEnemy();
        _navMeshAgent.SetDestination(playerPosition);
    }

    private void EnemyMovement()
    {
        Vector2 playerPosition = PlayerController.Instance.GetPlayerPosition();
        Vector2 enemyPosition = _transform.position;

        Vector2 enemyMovementVector = (playerPosition - enemyPosition).normalized;

        rb.MovePosition(rb.position + (enemyMovementVector * (_enemySpeed * Time.fixedDeltaTime)));
    }
}