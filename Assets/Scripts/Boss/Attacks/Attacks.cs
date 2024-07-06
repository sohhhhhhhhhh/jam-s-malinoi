using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Attacks : MonoBehaviour
{
    private BossBullet _bullet;
    private BossBullet spawnedBullet;

    private Vector3 BulletDirection;

    private bool isAttacking = false;
    private float _wavesDelay;
    private float _startAngel;
    private float _deltaAngel;
    private float _endAngel;
    private float _currentAngel;
    private int _waves;
    private float _bulletDelay;
    private float _deltaWaveAngel;

    public Attacks(
        float wavesDelay,
        float bulletDelay,
        float startAngel,
        float deltaAngel,
        float endAngel,
        int waves,
        float deltaWaveAngel
    )
    {
        _wavesDelay = wavesDelay;
        _bulletDelay = bulletDelay;
        _startAngel = startAngel;
        _deltaAngel = deltaAngel;
        _endAngel = endAngel;
        _currentAngel = startAngel;
        _waves = waves;
        _deltaWaveAngel = deltaWaveAngel;
    }

    public void SetAttacksSettings(
        float wavesDelay,
        float bulletDelay,
        float startAngel,
        float deltaAngel,
        float endAngel,
        int waves,
        float deltaWaveAngel,
        BossBullet bullet
    )
    {
        _wavesDelay = wavesDelay;
        _bulletDelay = bulletDelay;
        _startAngel = startAngel;
        _deltaAngel = deltaAngel;
        _endAngel = endAngel;
        _currentAngel = startAngel;
        _waves = waves;
        _deltaWaveAngel = deltaWaveAngel;
        _bullet = bullet;
    }

    public void StartAttack() {
        StartCoroutine(Attack());
    }

    public IEnumerator Attack()
    {
        for (int attackTicIndex = 0; attackTicIndex < _waves; attackTicIndex++)
        {
            for (_currentAngel = _startAngel; _currentAngel < _endAngel; _currentAngel += _deltaAngel)
            {
                BulletDirection = new Vector3(MathF.Sin((_currentAngel + _deltaWaveAngel * attackTicIndex) * Mathf.Deg2Rad),
                    MathF.Cos((_currentAngel + _deltaWaveAngel * attackTicIndex) * Mathf.Deg2Rad), 0);
                spawnedBullet = Instantiate(_bullet, transform.position + BulletDirection, Quaternion.identity);
                spawnedBullet.SetDirection(BulletDirection);

                yield return new WaitForSeconds(_bulletDelay);
            }

            yield return new WaitForSeconds(_wavesDelay);
        }
    }
}
