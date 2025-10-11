using UnityEngine;
using R3;

public class Test_R3_Subscribe : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Test_R3_Subject test_R3_Subject = GetComponent<Test_R3_Subject>();
        test_R3_Subject.testSubject.Subscribe(_ => Debug.Log("Hoge"));
        test_R3_Subject.testSubject.Subscribe(_ => Debug.Log("Hoge2"));
        test_R3_Subject.Test();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
