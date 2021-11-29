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
        
        // Start is called before the first frame update
        void Start()
        {

        }

        void Update()
        {
           
        }

        public void Move()
        {
            transform.Translate(Vector3.forward * speed);
        }
    }
}