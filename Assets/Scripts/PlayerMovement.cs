using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    Rigidbody2D rb;
    Animator animator;
    Vector2 movement;
    Vector2 facing = Vector2.down;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (!(movement.x == 0 && movement.y == 0))
        {
            facing = movement;
            animator.SetFloat("FacingHorizontal", facing.x);
            animator.SetFloat("FacingVertical", facing.y);
        }
    }

    void FixedUpdate()
    {
        // rb.velocity = movement.normalized * speed;
        rb.MovePosition(rb.position + movement.normalized * Time.fixedDeltaTime * speed);
    }
    
    public Vector2 GetFacingVector()
    {
        return facing;
    }

    public Vector2 GetMovementVector()
    {
        return movement;
    }
}
