using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Sprites;
using UnityEngine;

namespace FDVR
{
    //Attach this script to a GameObject to rotate around the target position.
    public class Wisp : MonoBehaviour
    {
        //Assign a GameObject in the Inspector to rotate around
        private GameObject target;

        public float playerDist;

        private void Start()
        {
            target = GameObject.FindWithTag("Player");
        }

        void Update()
        {
            //If the wisp sees you, swirl time
            if (Vector3.Distance(transform.position, target.transform.position) < playerDist)
            {
                StartCoroutine(Spin());
                EndGameManager.instance.hasEnded = true;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, playerDist);
        }

        private IEnumerator Spin()
        {
            // Spin the object around the target at 20 degrees/second.
            transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime);
            yield return new WaitForSeconds(5);
        }
    }
}