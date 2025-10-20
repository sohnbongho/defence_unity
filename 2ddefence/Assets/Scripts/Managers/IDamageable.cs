using UnityEngine;

public interface IDamageable
{
    void TakeDamage(int damage);
    bool IsAlive { get; }
    GameObject RelatedGameObject { get; }    
}
