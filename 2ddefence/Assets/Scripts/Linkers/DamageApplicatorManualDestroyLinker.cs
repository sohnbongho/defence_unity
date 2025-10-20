using UnityEngine;
using R3;

[RequireComponent(typeof(DamageApplicatorComponent), typeof(ManualDestroyComponent))]
public class DamageApplicatorManualDestroyLinker : MonoBehaviour
{
    private DamageApplicatorComponent _damageApplicator;
    private ManualDestroyComponent _manualDestroy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var damageApplicator = GetComponent<DamageApplicatorComponent>();
        var manualDestroy = GetComponent<ManualDestroyComponent>();

        if (damageApplicator == null || manualDestroy == null)
        {
            Debug.LogError("not found Component.");
            return;
        }

        damageApplicator.OnDamageApplied
            .Subscribe(target => manualDestroy.DestroySelf())
            .AddTo(this); // ���ҽ� ���� ������ ���� �߰�
    }

}
