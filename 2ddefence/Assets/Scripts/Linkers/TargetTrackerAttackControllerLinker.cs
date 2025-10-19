using UnityEngine;
using R3;

[RequireComponent(typeof(AttackControllerComponent))]
public class TargetTrackerAttackControllerLinker : MonoBehaviour
{
    [SerializeField] private TargetTrackerComponent _targetTracker;
    private AttackControllerComponent _attackController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _attackController = GetComponent<AttackControllerComponent>();

        if (_attackController == null)
        {
            Debug.LogError("not found Component.");
            return;
        }

        // _targetEnteredSubject.OnNext(damageable);
        _targetTracker.OnTargetAdded
        .Subscribe(target => _attackController.StartAttack())
        .AddTo(this);
    }

    private void Update()
    {
        if (_targetTracker.GetAliveTargets().Count == 0)
        {
            _attackController.EndAttack();
        }
    }
}
