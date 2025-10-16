using UnityEngine;
using R3;


public class HealthComponent : MonoBehaviour, IDamageable
{
    public int MaxHealth = 100;
    public int CurrentHealth;

    private bool _isAlive = true;
    public bool IsAlive => _isAlive;

    private readonly Subject<Unit> _deathSubject = new Subject<Unit>();
    public Observable<Unit> OnDeath => _deathSubject; // 이렇게 하면 외부에서 OnNext호출이 안된다.

    private void Awake()
    {
        CurrentHealth = MaxHealth;
        _isAlive = true;

        _deathSubject.AddTo(this); // 필수는 아니지만 추가하는 것이 좋다
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

        // OnNext: 알림을 하는 역활
        //      (OnDeath?.Invoke())와 같은 역활
        // DeathSubject를 구독하는 함수들 호출
        _deathSubject.OnNext(Unit.Default); // 사망을 알리는 코드
        Debug.Log("Die");
    }
}
