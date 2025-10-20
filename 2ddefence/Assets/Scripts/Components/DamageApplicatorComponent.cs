using UnityEngine;
using R3;

public class DamageApplicatorComponent : MonoBehaviour
{
    [SerializeField] int _attackPower = 15;
    private readonly Subject<Unit> _damageAppliedSubject = new Subject<Unit>();
    public Observable<Unit> OnDamageApplied => _damageAppliedSubject;

    private void Awake()
    {
        _damageAppliedSubject.AddTo(this);
    }

    public void ApplyDamage(IDamageable target)
    {
        if(target != null)
        {
            target.TakeDamage(_attackPower);
            _damageAppliedSubject.OnNext(Unit.Default);
        }
    }
    public void SetAttackPower(int newAttackPower)
    {
        _attackPower = newAttackPower;
    }
    
}
