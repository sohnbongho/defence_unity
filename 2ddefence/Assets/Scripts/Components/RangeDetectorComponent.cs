using R3;
using UnityEngine;

public class RangeDetectorComponent : MonoBehaviour
{
    private readonly Subject<IDamageable> _targetEnteredSubject = new Subject<IDamageable>();
    private readonly Subject<IDamageable> _targetExitedSubject = new Subject<IDamageable>();
    public Observable<IDamageable> OnTargetEntered => _targetEnteredSubject;
    public Observable<IDamageable> OnTargetExited => _targetExitedSubject;
    [SerializeField] private string _targetTag = "Enemy";
    void Awake()
    {
        _targetEnteredSubject.AddTo(this);
        _targetExitedSubject.AddTo(this);
    }

    // 충돌 영역에 들어왔을 때 동작.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(_targetTag))
        {
            var damageable = other.GetComponent<IDamageable>();
            if (damageable != null)
            {
                Debug.Log("Range OnTriggerEnter2D");
                _targetEnteredSubject.OnNext(damageable);
            }
        }
    }

    // 충돌 영역에 나갔을 때 동작
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(_targetTag))
        {
            var damageable = other.GetComponent<IDamageable>();
            if (damageable != null)
            {
                Debug.Log("Range OnTriggerExit2D");
                _targetExitedSubject.OnNext(damageable);
            }
        }
    }
}
