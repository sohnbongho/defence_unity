using UnityEngine;

public class HealthComponent : MonoBehaviour, IDamageable
{
    public int MaxHealth = 100;
    public int CurrentHealth;

    private bool _isAlive = true;
    public bool IsAlive => _isAlive;

    private void Awake()
    {
        CurrentHealth = MaxHealth;
        _isAlive = true;
    }

    public void TakeDamage(int damage)
    {
        if (!_isAlive)
        {
            return;
        }

        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            Die();
        }

    }
    public void Die()
    {
        if (!_isAlive)
        {
            return;
        }

        _isAlive = false;

        Debug.Log("Die");
    }
}
