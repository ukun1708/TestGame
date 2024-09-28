using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    private float speed;
    [SerializeField] private float maxSpeed;

    private Vector3 moveDirection;
    private Animator animator;
    private float inputMagnitude;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        inputMagnitude = Mathf.Clamp01(moveDirection.magnitude);
        animator.SetFloat("Input Magnitude", inputMagnitude, 0.05f, Time.deltaTime);
        speed = inputMagnitude * maxSpeed;
    }

    private void FixedUpdate()
    {
        rb.AddForce(moveDirection * speed, ForceMode.VelocityChange);

        rb.velocity = rb.velocity.normalized * speed;

        if (moveDirection.sqrMagnitude > .01f)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            rb.rotation = Quaternion.RotateTowards(rb.rotation, toRotation, 850 * Time.fixedDeltaTime);
        }
        else
        {
            rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.zero;
        }
    }

    private void OnMove(InputValue value)
    {
        moveDirection = new Vector3(value.Get<Vector2>().x, rb.velocity.y, value.Get<Vector2>().y);
    }
}
