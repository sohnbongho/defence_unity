using UnityEngine;
using R3;

[RequireComponent(typeof(RangeDetectorComponent), typeof(DamageApplicatorComponent))]
public class RangeDetectorDamageApplicatorLinker : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var rangeDetector = GetComponent<RangeDetectorComponent>();
        var damageApplicator = GetComponent<DamageApplicatorComponent>();

        if (rangeDetector == null || damageApplicator == null)
        {
            Debug.LogError("not found Component.");
            return;
        }

        rangeDetector.OnTargetEntered
            .Subscribe(target => damageApplicator.ApplyDamage(target))
            .AddTo(this); // 리소스 낭비 방지를 위해 추가
    }
}
