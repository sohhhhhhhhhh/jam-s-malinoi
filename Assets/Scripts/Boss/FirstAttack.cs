using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FirstAttack : AttackParent
{
    [SerializeField] private BossBullet _bullet;
    [SerializeField] private BossBullet spawnedBullet;
    private Vector3 BulletDirection;

    public bool isAttacking = false;
    public float startAngel;
    public float deltaAngel;
    public float endAngel;
    private float _currentAngel;
    
    public void Attack(float add)
    {
        _currentAngel += deltaAngel;
        BulletDirection = new Vector3(MathF.Sin((_currentAngel + add)* Mathf.Deg2Rad),
            MathF.Cos((_currentAngel + add)* Mathf.Deg2Rad), 0);
        spawnedBullet = Instantiate(_bullet, transform.position + BulletDirection, Quaternion.identity);
        spawnedBullet.Direction = (Vector2)BulletDirection;
    }

    public void ReloadWave()
    {
        _currentAngel = startAngel;
    }
}
