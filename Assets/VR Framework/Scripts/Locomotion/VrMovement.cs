using System;
using UnityEngine;
using System.Collections;

public class VrMovement : MonoBehaviour
{
    public float speed = 5f;
    private GameObject teleport;

    private void Start()
    {
        teleport = GameObject.FindGameObjectWithTag("FinalTeleport");
    }

    public void MovePlayer()
    {
        transform.Translate(Vector3.forward * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "TeleportPoint (2)")
        {
            transform.position = teleport.transform.position;
            transform.rotation = teleport.transform.rotation;
        }
    }
}