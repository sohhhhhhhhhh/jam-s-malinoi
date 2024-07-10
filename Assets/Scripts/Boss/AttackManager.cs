using UnityEngine;
using Random = UnityEngine.Random;

public class AttackManager : MonoBehaviour
{
    [SerializeField] private BossBullet bullet;
    private float _timer;
    private int _range;
    private int _attackIndex;
    private Attacks[] _attacks = new Attacks[5];
    private int _numOfAttacks = 3;

    private float[] _timerDelaysForEachAttacks = {
        4f, 6f, 1f
    };

    private void Awake()
    {
        _attacks[0] = gameObject.AddComponent<Attacks>();
        _attacks[0].SetAttacksSettings(
            0.3f, //wavesDelay или задержка между каждой волной атаки
            0f, // bulletDelay - задержка между выпуском каждой пули
            0, //startAngel - стартовый угол для атаки
            30, //deltaAngel - угол, на который происходит увеличение
            360, //endAngel - угол, на котором заканчивается волна атаки
            3, //waves - количество волн
            15, //deltaWavesAngel - угол, на который сдвигается следующая волна атаки
            bullet
        );
        _attacks[1] = gameObject.AddComponent<Attacks>();
        _attacks[1].SetAttacksSettings(
            1f, //wavesDelay или задержка между каждой волной атаки
            0.1f, // bulletDelay - задержка между выпуском каждой пули
            0, //startAngel - стартовый угол для атаки
            5f, //deltaAngel - угол, на который происходит увеличение
            360, //endAngel - угол, на котором заканчивается волна атаки
            1, //waves - количество волн
            15, //deltaWavesAngel - угол, на который сдвигается следующая волна атаки
            bullet
        );
        _attacks[_numOfAttacks - 1] = gameObject.AddComponent<Attacks>();
        _attacks[_numOfAttacks - 1].SetAttacksSettings(
            0.5f, //wavesDelay или задержка между каждой волной атаки
            0f, // bulletDelay - задержка между выпуском каждой пули
            0, //startAngel - стартовый угол для атаки
            90f, //deltaAngel - угол, на который происходит увеличение
            360, //endAngel - угол, на котором заканчивается волна атаки
            10, //waves - количество волн
            45, //deltaWavesAngel - угол, на который сдвигается следующая волна атаки
            bullet
        );
        _timer = _timerDelaysForEachAttacks[_attackIndex];
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer < 0)
        {
            _timer = _timerDelaysForEachAttacks[_attackIndex];
            _attacks[_attackIndex].StartAttack();
            _range = _attackIndex == _numOfAttacks - 1 ? _numOfAttacks - 1 : _numOfAttacks;
            _attackIndex = Random.Range(0, _range);
        }
    }
}