using UnityEngine;
using R3;

[RequireComponent(typeof(IntervalTimerComponent), typeof(ObjectSpawnerComponent))]
public class IntervalTimerObjectSpawnerLinker : MonoBehaviour
{
    private IntervalTimerComponent _timerComponent;
    private ObjectSpawnerComponent _spawnerComponent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var intervalTimer = GetComponent<IntervalTimerComponent>();
        var objectSpawner = GetComponent<ObjectSpawnerComponent>();

        if (intervalTimer == null || objectSpawner == null)
        {
            Debug.LogError("not found Component.");
            return;
        }

        // health.DeathSubject.OnNext가 실행되는 아래 함수 실행
        intervalTimer.OnIntervalElapsed
        .Subscribe(_ => objectSpawner.Spawn())
        .AddTo(this); // 리소스 낭비 방지를 위해 추가
    }
}
