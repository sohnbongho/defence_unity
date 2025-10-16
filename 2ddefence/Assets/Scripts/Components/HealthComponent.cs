using UnityEngine;
using R3;


public class HealthComponent : MonoBehaviour, IDamageable
{
    public int MaxHealth = 100;
    public int CurrentHealth;

    private bool _isAlive = true;
    public bool IsAlive => _isAlive;

    private readonly Subject<Unit> _deathSubject = new Subject<Unit>();
    public Observable<Unit> OnDeath => _deathSubject; // �̷��� �ϸ� �ܺο��� OnNextȣ���� �ȵȴ�.

    private void Awake()
    {
        CurrentHealth = MaxHealth;
        _isAlive = true;

        _deathSubject.AddTo(this); // �ʼ��� �ƴ����� �߰��ϴ� ���� ����
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

        // OnNext: �˸��� �ϴ� ��Ȱ
        //      (OnDeath?.Invoke())�� ���� ��Ȱ
        // DeathSubject�� �����ϴ� �Լ��� ȣ��
        _deathSubject.OnNext(Unit.Default); // ����� �˸��� �ڵ�
        Debug.Log("Die");
    }
}
