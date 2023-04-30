using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using Zenject;

public class CarMover : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rigidbody;

    [SerializeField, Range(0.1f, 10f)]
    private float maxSpeed = 10f;

    private IInputService inputService;

    private Vector3 startPos;

    [Inject]
    public void Construct(IInputService inputService)
    {
        this.inputService = inputService;
    }


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }


    float t = 0;

    private void Update()
    {
        t += 0.01f * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        Vector2 direction = inputService.MovementAction.ReadValue<Vector2>();


        float speed = Mathf.Lerp(0f, maxSpeed, t);
        float xMove = Mathf.Clamp(transform.position.x + direction.x * (speed / 2), -8f, 8f);
        float zMove = transform.position.z + speed;

        Debug.Log(speed);

        rigidbody.Move(new Vector3(xMove, transform.position.y, zMove), Quaternion.identity);
    }
}