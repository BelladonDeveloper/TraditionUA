using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController controller;
    public Transform cameraTransform;
    public float speed = 5.0f;
    public float jumpSpeed = 10.0f;
    public float gravity = -10.0f;
    public float sprintMultiplier = 2.0f;

    private Vector3 moveDirection;
    private bool isGrounded;

    void Update()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && controller.velocity.y < 0)
        {
            //controller.velocity = new Vector3(controller.velocity.x, 0f, controller.velocity.z);
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        moveDirection = new Vector3(horizontal, 0, vertical);

        if (Input.GetButton("Sprint"))
        {
            moveDirection *= speed * sprintMultiplier;
        }
        else
        {
            moveDirection *= speed;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }

        controller.Move(moveDirection * Time.deltaTime);

        moveDirection.y = controller.velocity.y + (gravity * Time.deltaTime);

        controller.Move(moveDirection * Time.deltaTime);
    }
}