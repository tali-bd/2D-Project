using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] float jumpHeight = 3;
    float horizontalDir;

    private Rigidbody2D rb;

    private bool isGrounded = false;

    //Start is called before the first frame update

    void Start()
    {
        //dir = new Vector2(x:0, y:0);

        rb = GetComponent<Rigidbody2D>();
    }

    //Update is called once per frame

    void Update()
    {
        rb.velocity = new Vector2(x: horizontalDir * speed, rb.velocity.y);

    }

    void OnMove(InputValue value)
    {
        Vector2 inputDir = value.Get<Vector2>();

        float inputX = inputDir.x;

        horizontalDir = inputX;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //is player touching floor?
        if(col.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }

    void OnJump()
    {
        if (isGrounded)
        {
            float requiredVelocity = (float) Mathf.Sqrt(2f * Physics.gravity.magnitude * jumpHeight);
            rb.velocity = new Vector2(rb.velocity.x, requiredVelocity);
        }
    }
}