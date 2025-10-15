using UnityEngine;

public class HealthComponent : MonoBehaviour, IDamageable
{
    public int MaxHealth = 100;
    public int CurrentHealth;
    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
    }
}
