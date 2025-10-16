using R3;
using UnityEngine;

public class AttackControllerComponent : MonoBehaviour
{
    private readonly Subject<Unit> _attackStartSubject = new Subject<Unit>();
    private readonly Subject<Unit> _attackEndSubject = new Subject<Unit>();
    public Observable<Unit> OnAttackStart => _attackStartSubject;
    public Observable<Unit> OnAttackEnd => _attackEndSubject;

    private bool _isAttacking = false;

    private void Awake()
    {
        // 메모리 보호용 
        _attackStartSubject.AddTo(this);
        _attackEndSubject.AddTo(this);
    }

    public void StartAttack()
    {
        if (!_isAttacking)
        {
            Debug.Log("Start Attack");
            _isAttacking = true;
            _attackStartSubject.OnNext(Unit.Default);
        }


    }
    public void EndAttack()
    {
        if (_isAttacking)
        {
            Debug.Log("End Attack");
            _isAttacking = false;
            _attackEndSubject.OnNext(Unit.Default);
        }
    }
}
