using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour {
    
    public static PlayerController Instance { get; private set; }
    
    private Rigidbody2D rb;
    private Transform _transform;

    private float _movementSpeed = 7.0f;
    private float minimalMovementSpeed = 0.1f;
    private bool isPlayerRunning = false;

   
    public int hp = 10;

    private void Awake() {
        Instance = this;

        rb = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
    }

    private void FixedUpdate() {
        HandleMovement();
    }

    private void HandleMovement() {
        Vector2 inputVector = GameInput.Instance.GetMovementVector();
        rb.MovePosition(rb.position + inputVector * (_movementSpeed * Time.fixedDeltaTime));

        if (Mathf.Abs(inputVector.x) > minimalMovementSpeed || Mathf.Abs(inputVector.y) > minimalMovementSpeed) {
            isPlayerRunning = true;
        }
        else {
            isPlayerRunning = false;
        }
    }

    public bool IsPlayerRunning() {
        return isPlayerRunning;
    }

    public Vector2 GetPlayerPosition() {
        Vector2 playerPosition = _transform.position;
        return playerPosition;
    }
    
    // я хз, повлияет ли разница вектор2 и вектор3 на что-нибудь
    public Vector3 GetPlayerScreenPosition() {
        Vector3 playerScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        return playerScreenPosition;
    }

    public Vector3 GetPositionForEnemy()
    {
        Vector3 position = _transform.position;
        return position;
    }

    public void getDamage(int damage) {
        hp -= damage;
        if (hp <= 0) {
            print("death");
            // TODO
        }
    }
}