using UnityEngine;
using R3;

public class Test_R3_Subscribe : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Test_R3_Subject test_R3_Subject = GetComponent<Test_R3_Subject>();
        test_R3_Subject.TestOpservable
            .Subscribe(_ => Debug.Log("Hoge"))
            .AddTo(this); // ������Ʈ�� �ı��ɶ� �˸� ������ �ڵ����� ����
        test_R3_Subject.TestOpservable
            .Subscribe(_ => Debug.Log("Hoge2"))
            .AddTo(this); // ������Ʈ�� �ı��ɶ� �˸� ������ �ڵ����� ����
        test_R3_Subject.Test();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
