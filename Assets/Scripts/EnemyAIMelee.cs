using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIMelee : MonoBehaviour
{
    private float _enemySpeed = 4.0f;
    private Rigidbody2D rb;
    private Transform _transform;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        EnemyMovement();
    }

    private void EnemyMovement()
    {
        Vector2 playerPosition = PlayerController.Instance.GetPlayerPosition();
        Vector2 enemyPosition = _transform.position;

        Vector2 enemyMovementVector = (playerPosition - enemyPosition).normalized;

        rb.MovePosition(rb.position + (enemyMovementVector * (_enemySpeed * Time.fixedDeltaTime)));
    }
}