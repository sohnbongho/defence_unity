using UnityEngine;
using R3;

public class ObjectSpawnerComponent : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    private readonly Subject<GameObject> _objectSpawnedSubject = new Subject<GameObject>();
    public Observable<GameObject> OnObjectSpawned => _objectSpawnedSubject;

    private void Awake()
    {
        _objectSpawnedSubject.AddTo(this);
    }
    public void Spawn()
    {
        var spawnedObject = Instantiate(_prefab, transform.position, Quaternion.identity);
        _objectSpawnedSubject.OnNext(spawnedObject);
    }
}
