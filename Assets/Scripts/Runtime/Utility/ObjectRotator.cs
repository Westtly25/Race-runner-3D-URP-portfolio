using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    [SerializeField]
    private Transform cachedTransform;

    [SerializeField, Range(- 10f, 10f)]
    private float rotationSpeed;

    private void Awake()
    {
        cachedTransform = transform;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
