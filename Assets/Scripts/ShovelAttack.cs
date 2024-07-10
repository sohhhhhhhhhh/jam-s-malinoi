using System;
using UnityEngine;

public class ShovelAttack : MonoBehaviour {
    [SerializeField] private Animator anim;
    [SerializeField] private float meleeSpeed;
    [SerializeField] private int meleeDamage;
    private EnemyStats ES;
    private BossBehaviour BS;
    [SerializeField] private float attackTime;
    public ShovelBarScript shovelBar;
    private float _timeWhileCanDealDamage = 0.75f;
    private float _timerWhileCanDealDamage = -1;
    float timeUntilMelee;

    void Start() {
        shovelBar.SetMaxTimer(meleeSpeed);
    }

    void Update() {
        shovelBar.SetTimer(meleeSpeed - timeUntilMelee);
        if (timeUntilMelee <= 0f) {
            if (Input.GetKey(KeyCode.Space) && PlayerController.Instance.isShovelGot) {
                anim.SetTrigger("Attack");
                timeUntilMelee = meleeSpeed;
                _timerWhileCanDealDamage = _timeWhileCanDealDamage;
            }
        }
        else {
            timeUntilMelee = Math.Max(timeUntilMelee - Time.deltaTime, -1);
            _timerWhileCanDealDamage = Math.Max(_timerWhileCanDealDamage - Time.deltaTime, -1) ;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enemy" && isDealingDamage()) {
            ES = other.gameObject.GetComponent<EnemyStats>();
            ES.getDamage(meleeDamage);
        }
        
        if (other.gameObject.tag == "Boss" && isDealingDamage()) {
            BS = other.gameObject.GetComponent<BossBehaviour>();
            BS.GetDamage(meleeDamage);
        }

    }

    private bool isDealingDamage()
    {
        return _timerWhileCanDealDamage > 0;
    }
}