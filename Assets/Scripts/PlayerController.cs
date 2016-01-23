using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rigidbody2d;
    public float MovementSpeed;
    public float JumpHeight;

	// Use this for initialization
	void Start () {
        rigidbody2d = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);

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

        if (Input.GetAxisRaw("Jump") != 0)
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, JumpHeight);
        }
#endif
    }
}
