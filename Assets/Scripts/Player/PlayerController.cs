using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public static PlayerController Instance { get; private set; }
    public GameObject gameOver;
    

    private Rigidbody2D rb;
    private Transform _transform;

    private float _movementSpeed = 7.0f;
    private float minimalMovementSpeed = 0.1f;
    private bool isPlayerRunning = false;
    public bool damaged_recently = false;
    public bool isShovelGot = false;
    private float red_timer = 0.3f;

    public int maxHP = 20;
    public int hp;
    public HealthBar healthBar;

    private void Awake() {
        Instance = this;

        rb = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
    }

    private void Start() {
        hp = maxHP;
        healthBar.SetMaxHealth(maxHP);
    }

    private void FixedUpdate() {
        HandleMovement();
        AfterDamaged();
        
        if (Input.GetKey(KeyCode.Return))
        {
            ChangeGameLevel();
        }
        if (hp <= 0) {
            gameOver.SetActive(true);
            if (Input.GetKey(KeyCode.Return))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                
            }
        }
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

    public Vector3 GetPositionForEnemy() {
        Vector3 position = _transform.position;
        return position;
    }

    public void getDamage(int damage) {
        damaged_recently = true;
        red_timer = 0.3f;
        transform.GetChild(2).GetComponent<SpriteRenderer>().color = Color.red;
        hp -= damage;
        healthBar.SetHealth(hp);
       
    }

    private void AfterDamaged() {
        if (red_timer >= 0) {
            red_timer -= Time.deltaTime;
        }
        else {
            transform.GetChild(2).GetComponent<SpriteRenderer>().color = Color.white;
        }
        
    }

    private void ChangeGameLevel()
    {
        PaperManager.Instance.HideDiaryImage();
        // TODO: ПЕРЕКЛЮЧЕНИЕ УРОВНЯ!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1
    }

}

