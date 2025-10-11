using UnityEngine;
using R3;

public class Test_R3_Subject : MonoBehaviour
{
    public Subject<Unit> testSubject = new Subject<Unit>();

    public void Test()
    {
        testSubject.OnNext(Unit.Default);

    }
}
