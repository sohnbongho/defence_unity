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
            .AddTo(this); // 오브젝트가 파괴될때 알림 구독도 자동으로 해제
        test_R3_Subject.TestOpservable
            .Subscribe(_ => Debug.Log("Hoge2"))
            .AddTo(this); // 오브젝트가 파괴될때 알림 구독도 자동으로 해제
        test_R3_Subject.Test();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
