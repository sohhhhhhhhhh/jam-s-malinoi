using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public static BossBullet Instance { get; private set; }
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private int damage = 10;
    private bool IsNotKilledByPlayer = true;
    private bool _IsBig = false;
    private Vector3 _direction;
    private Renderer _renderer;

    private BossBullet spawnedBullet;
    private Vector3 BulletDirection;

    [SerializeField] private float startAngel;
    [SerializeField] private float deltaAngel;
    [SerializeField] private float endAngel;
    private float _currentAngel;
    private float _attacks = 3;
    private float _addAngel;

    public void SetDirection(Vector3 direction) {
        _direction = direction;
    }

    public void SetType(bool isBig)
    {
        if (!isBig)
        {
            print("SetType");
        }

        _IsBig = isBig;
    }

    private void Start() {
        print("wagag");
        Instance = this;
        if (!_IsBig) {
            print("Start");
        }
        _renderer = GetComponent<Renderer>();
        _currentAngel = startAngel;
        rb = GetComponent<Rigidbody2D>();

        if (_IsBig) {
            _direction =
            (
                PlayerController.Instance.GetPlayerPosition() - new Vector2(
                    transform.position.x,
                    transform.position.y
                )
            ).normalized;
            _renderer.material.color = Color.red;
        }
        else
        {
            _renderer.material.color = Color.yellow;
        }
        rb.velocity = _direction * speed;
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            PlayerController.Instance.getDamage(damage);
            IsNotKilledByPlayer = false;
        }

        if (col.gameObject.tag != "Boss" && col.gameObject.tag != "Bullet") {
            Destroy(gameObject);
        }
    }

    private void OnDestroy() {
        Destroy(gameObject);
    }
}
