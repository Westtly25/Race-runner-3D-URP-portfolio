using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Movement_System
{
    public class AICarMover : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody rigidbody;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            rigidbody.Move(transform.position + (Vector3.forward * 1f * Time.fixedDeltaTime), transform.rotation);
        }
    }
}
