using UnityEngine;
using R3;

[RequireComponent(typeof(HealthComponent), typeof(ManualDestroyComponent))]
public class HealthManualDestroyLinker : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var health = GetComponent<HealthComponent>();
        var manualDestoy = GetComponent<ManualDestroyComponent>();

        if (health == null || manualDestoy == null)
        {
            Debug.LogError("not found Component.");
            return;
        }

        // health.DeathSubject.OnNext�� ����Ǵ� �Ʒ� �Լ� ����
        health.OnDeath
        .Subscribe(_ => manualDestoy.DestroySelf())
        .AddTo(this); // ���ҽ� ���� ������ ���� �߰�
    }

    // Update is called once per frame
    void Update()
    {

    }
}
