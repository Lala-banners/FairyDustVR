using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FDVR
{
    //Attach this script to a GameObject to rotate around the target position.
    public class Wisp : MonoBehaviour
    {
        //Assign a GameObject in the Inspector to rotate around
        private GameObject target;

        //How fast the object circles the target
        [SerializeField] private float rotationSpeed = 150;

        [SerializeField] private float playerDist;

        private Animator wispAnimator;

        private void Start()
        {
            wispAnimator = GetComponent<Animator>();
            target = GameObject.FindGameObjectWithTag("Player");
        }

        void Update()
        {
            // Spin the object around the target at desired degrees/second.
            //transform.RotateAround(target.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);

            /*if (Vector3.Distance(transform.position, target.transform.position) < playerDist)
            {
                StartCoroutine(WispAnimation());
            }*/

            wispAnimator.SetBool("IsIdle", !Input.GetKeyDown(KeyCode.A));
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, playerDist);
        }
    }
}