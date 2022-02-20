using System;
using UnityEngine;

public sealed class AttackComponent : MonoBehaviour
{
    public Action OnAttackFinished;

    public int Damage
    {
        get => damage;
    }

    [SerializeField]
    private int damage;

    [SerializeField] 
    private Animation attackEffect;

    public void Attack(GameObject enemy)
    {
        if (!enemy.TryGetComponent(out HealthComponent enemyHealth))
        {
            return;
        }
        
        if (enemyHealth.IsDead)
        {
            // this.OnAttackFinished?.Invoke();
            return;
        }

        enemyHealth.ApplyDamage(damage);
        this.OnAttackFinished?.Invoke();
    }

    public void Attack(HealthComponent enemy)
    {
        if (enemy.IsDead)
        {
            // this.OnAttackFinished?.Invoke();
            return;
        }

        enemy.ApplyDamage(damage);
        if (attackEffect) attackEffect.Play();
        
        this.OnAttackFinished?.Invoke();
    }
}