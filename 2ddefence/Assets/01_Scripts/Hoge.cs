using System;
using UnityEngine;

public class Hoge : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Debug.Log("Start");
        CreateCharacter();
    }

    private void CreateCharacter()
    {
        Instantiate(prefab, new Vector3(0,0,0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
