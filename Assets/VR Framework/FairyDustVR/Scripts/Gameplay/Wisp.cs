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

        [SerializeField] private float playerDist;

        private Animator wispAnimator;

        private void Start()
        {
            wispAnimator = GetComponent<Animator>();
            target = GameObject.FindGameObjectWithTag("Player");
        }

        void Update()
        {
            if (Vector3.Distance(transform.position, target.transform.position) < playerDist)
            {
                wispAnimator.SetBool("IsIdle", false);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, playerDist);
        }
    }
}