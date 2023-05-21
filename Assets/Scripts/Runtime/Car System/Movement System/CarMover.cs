using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using Zenject;

public class CarMover : MonoBehaviour
{
    [SerializeField]
    private Rigidbody carRigidbody;

    [SerializeField, Range(0f, 500f)]
    private float maxSpeed = 10f;

    [SerializeField, Range(0f, 500f)]
    private float currentSpeed;

    private IInputService inputService;

    private Vector3 startPos;

    [Inject]
    public void Construct(IInputService inputService)
    {
        this.inputService = inputService;
    }


    private void Awake()
    {
        carRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        GetTravelledDistance();
    }

    public void GetTravelledDistance()
    {
       Vector3 distance = this.transform.position - startPos;
    }

    private void IncreaseSpeed()
    {
        currentSpeed += 0.1f * Time.fixedDeltaTime;
    }

    private float SpeedInKmPerHour()
    {
        return currentSpeed / 3.6f;
    }

    private Vector3 MoveDirection()
    {
        Vector2 direction = inputService.MovementAction.ReadValue<Vector2>();

        float xMove = Mathf.Clamp(carRigidbody.position.x + direction.x * ((SpeedInKmPerHour() / 2f) * Time.fixedDeltaTime), -8f, 8f);
        float zMove = carRigidbody.position.z + SpeedInKmPerHour() * Time.fixedDeltaTime;

        return new Vector3(xMove, carRigidbody.position.y, zMove);
    }

    private void FixedUpdate()
    {
        IncreaseSpeed();

        carRigidbody.Move(MoveDirection(), Quaternion.identity);
    }
}