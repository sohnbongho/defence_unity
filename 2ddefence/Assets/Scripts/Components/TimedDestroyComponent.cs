using UnityEngine;

public class TimedDestroyComponent : MonoBehaviour
{
    [SerializeField] private float _timeToDestroy = 1f;

    private void Start()
    {
        Destroy(gameObject, _timeToDestroy);
    }

    private void OnValidate()
    {
        _timeToDestroy = Mathf.Max(0f, _timeToDestroy);
    }
}
