using UnityEngine;

namespace Assets.Scripts.Runtime.Camera_System
{
    public class CameraFollow : MonoBehaviour
{
    [SerializeField, Range(1f, 10f)]
    public float smoothness;
    [SerializeField]
    public Transform targetObject;
    [SerializeField]
    private Vector3 initalOffset;
    [SerializeField]
    private Vector3 cameraPosition;

    //[Inject]
    //public void Construct(Player player)
    //{
    //    this.targetObject = player.gameObject.transform;
    //}

    private void Awake()
    {
        if(targetObject == null)
        {
#if UNITY_EDITOR
            Debug.LogError("Camera doesn't have target to follow");
#endif
            return;
        }

        transform.position = targetObject.position + initalOffset;
    }

    void FixedUpdate()
    {
        cameraPosition = targetObject.position + initalOffset;
        transform.position = Vector3.Lerp(transform.position, cameraPosition, smoothness * Time.fixedDeltaTime);
    }
}
}