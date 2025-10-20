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

        // health.DeathSubject.OnNext�� ����Ǵ� �Ʒ� �Լ� ����
        attackController.OnAttackStart
            .Subscribe(_ => intervalTimer.Active())
            .AddTo(this); // ���ҽ� ���� ������ ���� �߰�

        attackController.OnAttackEnd
            .Subscribe(_ => intervalTimer.DeActive())
            .AddTo(this); // ���ҽ� ���� ������ ���� �߰�
    }

}
