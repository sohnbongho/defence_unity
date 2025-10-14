using UnityEngine;
using R3;

public class Test_R3_Subject : MonoBehaviour
{
    private readonly Subject<Unit> testSubject = new Subject<Unit>();
    public Subject<Unit> TestOpservable => testSubject;

    private void Awake()
    {
        // ������Ʈ�� �ı��ɶ� �˸� ������ �ڵ����� ����
        // �޸� ���� ������:�ʼ��� �ƴ�
        testSubject.AddTo(this);
    }

    public void Test()
    {
        testSubject.OnNext(Unit.Default);

    }
}
