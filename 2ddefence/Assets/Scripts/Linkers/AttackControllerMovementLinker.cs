using UnityEngine;
using R3;

[RequireComponent(typeof(AttackControllerComponent), typeof(MovementComponent))]
public class AttackControllerMovementLinker : MonoBehaviour
{
    private AttackControllerComponent _attackController;
    private MovementComponent _movementComponent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var attackController = GetComponent<AttackControllerComponent>();
        var movement = GetComponent<MovementComponent>();

        if (attackController == null || movement == null)
        {
            Debug.LogError("not found Component.");
            return;
        }

        attackController.OnAttackStart
            .Subscribe(_ => movement.StopMoving())
            .AddTo(this); // 리소스 낭비 방지를 위해 추가

        attackController.OnAttackEnd
            .Subscribe(_ => movement.StartMoving())
            .AddTo(this); // 리소스 낭비 방지를 위해 추가
    }
}
