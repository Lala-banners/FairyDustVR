using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using VRFramework.Input;
using UnityEditor;
using UnityEngine.UI;

namespace VRFramework
{
    public class VrMovement : MonoBehaviour
    {
        public float speed;
        public float jumpForce;
        Rigidbody rb;
        
        /*public float charHeight;
        public float heightPadding;
        public LayerMask ground;
        public float maxGroundAngle = 120;
        public bool debug;

        private float groundAngle;

        private Vector3 forward;
        private RaycastHit hitInfo;
        private bool isGrounded;*/

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void Jump()
        {
            rb.AddForce(Vector3.up * jumpForce);
        }

        public void Move()
        {
            transform.Translate(Vector3.forward * speed);
        }
    }
}