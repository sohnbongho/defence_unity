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
            .AddTo(this); // ���ҽ� ���� ������ ���� �߰�

        attackController.OnAttackEnd
            .Subscribe(_ => movement.StartMoving())
            .AddTo(this); // ���ҽ� ���� ������ ���� �߰�
    }
}
