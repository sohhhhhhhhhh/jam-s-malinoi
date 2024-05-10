using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float _movementSpeed = 7.0f;
    private Transform _transform;
    public static PlayerController Instance { get; private set; }
    public int hp = 10;
    
    private void Awake() {
        Instance = this;
        
        rb = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
    }
    private void FixedUpdate() {
        Vector2 inputVector = GameInput.Instance.GetMovementVector();
        rb.MovePosition(rb.position + inputVector * (_movementSpeed * Time.fixedDeltaTime));
    }

    public Vector2 GetPlayerPosition()
    {
        Vector2 playerPosition = _transform.position;
        return playerPosition;
    }

    public Vector3 GetPositionForEnemy()
    {
        Vector3 position = _transform.position;
        return position;
    }

    public void getDamage(int damage) {
        hp -= damage;
        if (hp <= 0) {
            Destroy(this.gameObject);
        }
    }
}
