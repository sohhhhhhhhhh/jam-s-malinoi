using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    private int _attackIndex = 0;
    private Attacks[] _attacks = {
        new Attacks(
            0.3f, //wavesDelay или задержка между каждой волной атаки
            0f, // bulletDelay - задержка между выпуском каждой пули
            0, //startAngel - стартовый угол для атаки
            30, //deltaAngel - угол, на который происходит увеличение
            360, //endAngel - угол, на котором заканчивается волна атаки
            3, //waves - количество волн
            15 //deltaWavesAngel - угол, на который сдвигается следующая волна атаки
        )
    };

    private void Start()
    {
        print(_attackIndex);
        _attacks[_attackIndex].StartAttack();
    }

    private void checkAttackStart()
    {

    }

    private void startAttack() {

    }
}