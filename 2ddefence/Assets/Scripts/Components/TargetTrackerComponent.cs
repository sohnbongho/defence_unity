using UnityEngine;
using R3;
using System.Collections.Generic;

public class TargetTrackerComponent : MonoBehaviour
{
    private List<IDamageable> _targets = new List<IDamageable>();
    private readonly Subject<IDamageable> _targetAddedSubject = new Subject<IDamageable>();
    public Observable<IDamageable> OnTargetAdded => _targetAddedSubject;

    private void Awake()
    {
        _targetAddedSubject.AddTo(this);
    }
    public void AddTarget(IDamageable target)
    {
        if (target != null && target.IsAlive && !_targets.Contains(target))
        {
            _targets.Add(target);
            Debug.Log($"AddTarget {_targets.Count}");
            _targetAddedSubject.OnNext(target);
        }
    }

    public void RemoveTarget(IDamageable target)
    {
        if (target != null && _targets.Contains(target))
        {
            _targets.Remove(target);
            Debug.Log($"RemoveTarget {_targets.Count}");
        }
    }
    public List<IDamageable> GetAliveTargets()
    {
        _targets.RemoveAll(t => t == null || !t.IsAlive);
        return new List<IDamageable>(_targets);
    }
}
