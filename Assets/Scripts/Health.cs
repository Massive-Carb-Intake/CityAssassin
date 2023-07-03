using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float health = 100;

    public float GetHealth()
    {
        return health;
    }
    public void SetHealth(float health)
    {
        this.health = health;
    }
    
    private bool _isDead;

    public bool GetIsDead()
    {
        return _isDead;
    }
    public void SetIsDead(bool isDead)
    {
        _isDead = isDead;
    }

    public void ApplyDamage(float damageToApply)
    {
        health -= damageToApply;
        if (health <= 0)
        {
            SetIsDead(true);
            SetHealth(0);
        }
        else
        {
            SetIsDead(false);
        }
    }
}
