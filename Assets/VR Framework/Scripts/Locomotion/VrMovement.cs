using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using VRFramework.Input;

namespace VRFramework
{
    public class VrMovement : MonoBehaviour
    {
        public float speed;

        private void Update()
        {
            if (UnityEngine.Input.GetButton("Jump"))
            {
                
            }
        }

        public void Move()
        {
            transform.Translate(Vector3.forward * speed);
        }
        
        
    }
}