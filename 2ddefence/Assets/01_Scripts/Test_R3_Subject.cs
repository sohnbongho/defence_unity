using UnityEngine;
using R3;

public class Test_R3_Subject : MonoBehaviour
{
    private readonly Subject<Unit> testSubject = new Subject<Unit>();
    public Subject<Unit> TestOpservable => testSubject;

    private void Awake()
    {
        // 오브젝트가 파괴될때 알림 구독도 자동으로 해제
        // 메모리 누구 방지용:필수는 아님
        testSubject.AddTo(this);
    }

    public void Test()
    {
        testSubject.OnNext(Unit.Default);

    }
}
