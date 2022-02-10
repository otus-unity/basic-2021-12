using System;
using UnityEngine;

public sealed class HealthComponent : MonoBehaviour
{
    public Action<int> OnHealthChanged;
    
    public Action OnDead;

    public int Health
    {
        get => health;
    }

    public bool IsDead
    {
        get => isDead;
    }
    
    [SerializeField]
    private int health;

    [SerializeField]
    private bool isDead;

    public void ApplyDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            isDead = true;
            health = 0;
            OnDead?.Invoke();
        }

        OnHealthChanged?.Invoke(health);
    }

    public void ApplyDamage(AttackComponent attackComponent)
    {
        health -= attackComponent.Damage;

        if (health <= 0)
        {
            isDead = true;
            health = 0;
            OnDead?.Invoke();
        }

        OnHealthChanged?.Invoke(health);
    }
}