using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    private int _hp = 20;

    public void GetDamage(int damage)
    {
        _hp -= damage;
        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
