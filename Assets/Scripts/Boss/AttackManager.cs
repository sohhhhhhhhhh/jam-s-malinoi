using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< Updated upstream
public class AttackManager : MonoBehaviour {
    private Dictionary<Attack, float[]> AttackInfo;
    [SerializeField] private FirstAttack _firstAttack;
=======
public class AttackManager : MonoBehaviour
{
    private Dictionary<AttackParent, float[]> AttackInfo;
    [SerializeField]private FirstAttack _firstAttack;
    private float[] xd;
    private AttackParent[] _attacks;
>>>>>>> Stashed changes
    private int currentAttackIndex = 0;
    private float NumOfAttacks = 1;
    private float NumOfWaves = 3;
    private int WaveNum = 3;
    private float remainingPatrons = 38;
    private float timerWave = 3;
    private float timeWave = 3;
    private bool canWave;
    private bool canAttack;

    private float timeUnderWave = 0.5f;
    private float timerUnderWave = 0.5f;
    private bool canUnderWave;
<<<<<<< Updated upstream

    void Start() {
=======
    
    void Start()
    {
        _attacks[0] = _firstAttack;
>>>>>>> Stashed changes
        AttackInfo[_firstAttack] = new float[]
        { NumOfWaves, NumOfAttacks, remainingPatrons, timerWave, timeWave, timerUnderWave, timeUnderWave };
    }

    void Update() {
        if (!canWave) {
            UpdateWaveTimer();
        }

        if (!canUnderWave) {
            UpdateUnderWaveTimer();
        }

<<<<<<< Updated upstream
        if (canWave && canUnderWave) {
=======
        remainingPatrons = AttackInfo[_attacks[currentAttackIndex]][2];

        if (canWave && canUnderWave)
        {
>>>>>>> Stashed changes
            _firstAttack.Attack((remainingPatrons / 13) * 15);
            remainingPatrons--;
            if (remainingPatrons <= 0) {
                canWave = false;
                remainingPatrons = 38;
            }

            if (remainingPatrons % 13 == 0) {
                canUnderWave = false;
                if (remainingPatrons == 0) {
                    currentAttackIndex = UnityEngine.Random.Range(0, (int)NumOfAttacks - 1);
                }
            }
        }
    }

    void UpdateWaveTimer() {
        timerWave -= Time.deltaTime;
        if (timerWave <= 0) {
            canWave = true;
            timerWave = timeWave;
        }
    }

    void UpdateUnderWaveTimer() {
        timerUnderWave -= Time.deltaTime;
        if (timerUnderWave <= 0) {
            canUnderWave = true;
            timerUnderWave = timeUnderWave;
        }
    }
<<<<<<< Updated upstream
}
=======

    void updateVariable()
    {
        xd = AttackInfo[_attacks[currentAttackIndex]];

        NumOfWaves = xd[0];
        NumOfAttacks = xd[1];
        remainingPatrons = xd[2];
        timerWave = xd[3];
        timeWave = xd[4];
        timerUnderWave = xd[5];
        timeUnderWave = xd[6];
    }
}
>>>>>>> Stashed changes
