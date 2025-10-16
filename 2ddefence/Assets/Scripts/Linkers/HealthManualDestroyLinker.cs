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

        // health.DeathSubject.OnNext가 실행되는 아래 함수 실행
        health.OnDeath
        .Subscribe(_ => manualDestoy.DestroySelf())
        .AddTo(this); // 리소스 낭비 방지를 위해 추가
    }

    // Update is called once per frame
    void Update()
    {

    }
}
