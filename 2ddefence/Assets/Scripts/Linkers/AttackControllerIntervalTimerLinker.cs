using UnityEngine;
using R3;

[RequireComponent(typeof(AttackControllerComponent), typeof(IntervalTimerComponent))]
public class AttackControllerIntervalTimerLinker : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var attackController = GetComponent<AttackControllerComponent>();
        var intervalTimer = GetComponent<IntervalTimerComponent>();

        if (attackController == null || intervalTimer == null)
        {
            Debug.LogError("not found Component.");
            return;
        }

        // health.DeathSubject.OnNext가 실행되는 아래 함수 실행
        attackController.OnAttackStart
            .Subscribe(_ => intervalTimer.Active())
            .AddTo(this); // 리소스 낭비 방지를 위해 추가

        attackController.OnAttackEnd
            .Subscribe(_ => intervalTimer.DeActive())
            .AddTo(this); // 리소스 낭비 방지를 위해 추가
    }

}
