using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FDVR
{
    //Attach this script to a GameObject to rotate around the target position.
    public class Wisp : MonoBehaviour
    {
        //Assign a GameObject in the Inspector to rotate around
        public GameObject target;

        //How fast the object circles the target
        [SerializeField] private float rotationSpeed = 150;

        void Update()
        {
            // Spin the object around the target at desired degrees/second.
            transform.RotateAround(target.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}