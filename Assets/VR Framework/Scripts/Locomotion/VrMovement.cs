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
        //Vector3 moveDirection = Vector3.zero;
        Rigidbody rb;

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
            
            /*Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
            float curSpeedX = UnityEngine.Input.GetAxis("Vertical");
            float curSpeedY = UnityEngine.Input.GetAxis("Horizontal");
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);*/
        }
    }
}