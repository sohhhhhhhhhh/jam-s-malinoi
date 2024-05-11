using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyAIArcher : MonoBehaviour {
    public GameObject bullet;
    public float fireRate;
    private float timer;
    private bool canFire = true;


    private NavMeshAgent _navMeshAgent;
    [SerializeField] private State startingState;
    private State _state;
    private float _roamingDistanceMax = 7.0f;
    private float _roamingDistanceMin = 3.0f;
    private float _roamingTimerMax = 2.0f;
    private float _roamingTime;
    private Vector3 _roamPosition;
    private Vector3 _startingPosition;
    [SerializeField] private Transform transform;


    private enum State {
        Idle,
        Roaming
    }

    private void Awake() {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
        _state = startingState;
    }


    void Start() {
        timer = fireRate;
        _startingPosition = transform.position;
    }

    void Update() {
        updateTimer();
        if (canFire) {
            Instantiate(bullet, transform.position, Quaternion.identity);
            canFire = false;
        }

        switch (_state) {
            default:
            case State.Idle:
                break;
            case State.Roaming:
                _roamingTime -= Time.deltaTime;
                if (_roamingTime < 0) {
                    Roaming();
                    _roamingTime = _roamingTimerMax;
                }
                break;
        }
    }

    private void FixedUpdate() {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), 3)) {
            _roamingTime = -1;
        }
    }

    void updateTimer() {
        if (!canFire) {
            timer -= 1 * Time.deltaTime;
            if (timer <= 0) {
                canFire = true;
                timer = fireRate;
            }
        }
    }

    private void Roaming() {
        _roamPosition = GetRoamingPosition();
        _navMeshAgent.SetDestination(_roamPosition);
    }

    private Vector3 GetRoamingPosition() {
        Vector3 randomVector = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        return _startingPosition + randomVector * UnityEngine.Random.Range(_roamingDistanceMin, _roamingDistanceMax);
    }
}