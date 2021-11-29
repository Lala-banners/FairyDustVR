using System;
using UnityEngine;
using System.Collections;

public class VrMovement : MonoBehaviour
{
    public float speed = 5f;

    public void MovePlayer()
    {
        transform.Translate(Vector3.forward * speed);
    }
}