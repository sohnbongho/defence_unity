using UnityEngine;
using R3;

public class IntervalTimerComponent : MonoBehaviour
{
    [SerializeField] float _interval = 1.0f;
    private float _timer = 0f;
    private readonly Subject<Unit> _intervalElapsedSubject = new Subject<Unit>();
    public Observable<Unit> OnIntervalElapsed => _intervalElapsedSubject;
    private void Awake()
    {
        _intervalElapsedSubject.AddTo(this);
    }


    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _interval)
        {
            _intervalElapsedSubject.OnNext(Unit.Default);
            Debug.Log($"IntervalTimer Event {_interval}second");
            _timer = 0.0f;
        }
    }
}
