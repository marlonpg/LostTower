using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rigidbody2d;
    public float MovementSpeed;
    public float JumpHeight;
    private bool doubleJump;

    // GroundCheck
    public LayerMask WhatIsGround;
    public float GroundRadiusCheck;
    private bool isGrounded;

	// Use this for initialization
	void Start () {
        rigidbody2d = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
        // Camera follows player position
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
        // Ground check
        isGrounded = Physics2D.OverlapCircle(transform.position,GroundRadiusCheck,WhatIsGround);

        if (isGrounded)
        {
            doubleJump = false;
        }

        if (rigidbody2d.velocity.x > 0)
        {
            transform.localScale = new Vector3(1,1,1);
        }
        if (rigidbody2d.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

#if UNITY_EDITOR
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            rigidbody2d.velocity = new Vector2(MovementSpeed, rigidbody2d.velocity.y);
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            rigidbody2d.velocity = new Vector2(-MovementSpeed, rigidbody2d.velocity.y);
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                doubleJump = false;
                rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, JumpHeight);
            }
            else
            {
                if (!doubleJump)
                {
                    doubleJump = true;
                    rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, JumpHeight);
                }
            }      
        }
#endif
    }
}
