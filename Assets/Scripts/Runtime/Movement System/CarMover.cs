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
    private float currentSpeed = 1f;

    [SerializeField]
    private float maxSpeed = 10f;

    private IInputService inputService;

    [Inject]
    public void Construct(IInputService inputService)
    {
        this.inputService = inputService;
    }


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector2 direction = inputService.MovementAction.ReadValue<Vector2>();

        rigidbody.Move(new Vector3(transform.position.x + direction.x * currentSpeed * Time.deltaTime,
                                   transform.position.y,
                                   transform.position.z + currentSpeed * Time.deltaTime),
                                   Quaternion.identity);
    }
}
