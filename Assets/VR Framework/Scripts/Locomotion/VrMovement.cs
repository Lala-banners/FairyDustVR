using UnityEngine;
using System.Collections;

public class VrMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    Rigidbody rb;
    private CharacterController _controller;
    private Vector3 moveDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        _controller = GetComponent<CharacterController>();
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce);
    }

    public void MovePlayer()
    {
        if (_controller.isGrounded)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);

            float curSpeedX = speed * Input.GetAxis("Vertical");
            float curSpeedY = speed * Input.GetAxis("Horizontal");

            moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        }

        _controller.Move(moveDirection * Time.deltaTime);
    }
}