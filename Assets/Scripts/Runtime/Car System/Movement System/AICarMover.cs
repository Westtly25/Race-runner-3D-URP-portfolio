using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Movement_System
{
    [RequireComponent(typeof(Rigidbody))]
    public class AICarMover : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody carRigidbody;

        private void Awake()
        {
            carRigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (carRigidbody.position.x > 0)
            {
                carRigidbody.Move(carRigidbody.position + (Vector3.forward * 1f * Time.fixedDeltaTime), carRigidbody.rotation);
            }
            else carRigidbody.Move(carRigidbody.position - (Vector3.forward * 1f * Time.fixedDeltaTime), carRigidbody.rotation);
        }
    }
}
