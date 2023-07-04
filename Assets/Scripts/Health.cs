using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    private float _currentHealth;

    public float GetMaxHealth()
    {
        return maxHealth;
    }
    
    public float GetCurrentHealth()
    {
        return _currentHealth;
    }
    public void SetCurrentHealth(float health)
    {
        this._currentHealth = health;
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
        _currentHealth -= damageToApply;
        if (_currentHealth <= 0)
        {
            SetIsDead(true);
            SetCurrentHealth(0);
        }
        else
        {
            SetIsDead(false);
        }
    }

    private void Start()
    {
        _currentHealth = maxHealth;
    }
}