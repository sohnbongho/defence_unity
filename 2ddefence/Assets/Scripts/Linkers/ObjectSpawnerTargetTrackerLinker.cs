using UnityEngine;
using R3;

[RequireComponent(typeof(ObjectSpawnerComponent), typeof(TargetTrackerComponent))]
public class ObjectSpawnerTargetTrackerLinker : MonoBehaviour
{
    [SerializeField] private TargetTrackerComponent _targetTracker;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        var objectSpawner = GetComponent<ObjectSpawnerComponent>();
        if (objectSpawner == null || _targetTracker == null)
        {
            Debug.LogError("not found Component.");
            return;
        }
        objectSpawner.OnObjectSpawned
            .Subscribe(spawnedObject => HandleObjectSpawned(spawnedObject))
            .AddTo(this);
    }
    private void HandleObjectSpawned(GameObject spawnedObject)
    {
        var movement = spawnedObject.GetComponent<MovementComponent>();
        if (movement == null)
        {
            Debug.LogError("not found Component.");
            return;
        }

        var closestTarget = _targetTracker.FindClosestTarget(spawnedObject.transform.position);
        if (closestTarget != null)
        {
            Vector3 direction = (closestTarget.RelatedGameObject.transform.position - spawnedObject.transform.position).normalized;
            movement.SetDirection(direction);
        }

    }
}
