using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
	Rigidbody rb;
	public float degrees;
	public float zOffset;
	public float xOffset;
    PhysicsController physicsController;

    //public Collider head;
	//public Collider body;
	//public Collider mesh;
	public float health = 500.0f;
	public float speed = .1f;
    [SerializeField] float jumpSpeed = 1f;

    //[SerializeField] float eulerAngX;
    ////[SerializeField] float eulerAngY;
    //[SerializeField] float eulerAngZ;

    void Start()
    {
        physicsController = GetComponent<PhysicsController>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
	{
        //eulerAngX = transform.localRotation.eulerAngles.x;
        //eulerAngY = transform.localRotation.eulerAngles.y;
        //eulerAngZ = transform.localRotation.eulerAngles.z;// transform.localEulerAngles.z;
        degrees = transform.localRotation.eulerAngles.y;
        zOffset = speed * (float)Math.Cos((degrees) / 180 * Math.PI);
        xOffset = speed * (float)Math.Sin((degrees) / 180 * Math.PI);

        /*if (physicsController.IsGrounded() && rb.velocity.magnitude < 0.005)
        {
            if (Input.GetButton("Jump"))
            {
                applyForce = true;
            }
        }
        else
        {
            applyForce = false;
        }*/

        /**if (physicsController.IsXNegWall())
        {
                xOffset = 0f;
        }

        if (physicsController.IsXPosWall())
        {
                xOffset = 0f;
        }

        if (physicsController.IsZNegWall())
        {
                zOffset = 0f;
        }

        if (physicsController.IsZPosWall())
        {
                zOffset = 0f;
        }**/

        //transform.position = new Vector3(transform.position.x + (moveVector.x), transform.position.y, transform.position.z + (moveVector.z));

        Debug.Log("X Offset: " + xOffset + ", Z Offset: " + zOffset);
       // Debug.Log("forward: " + transform.forward);

        if (Input.GetKey(KeyCode.W))
		{
            if (physicsController.IsFrontWall())
            {
                xOffset = 0;
                zOffset = 0;
            }
            transform.position = new Vector3(transform.position.x + xOffset, transform.position.y, transform.position.z + zOffset);
		}
		if (Input.GetKey(KeyCode.S))
		{
            if (physicsController.IsBackWall()) {
                xOffset = 0;
                zOffset = 0;
            }
            transform.position = new Vector3(transform.position.x - xOffset, transform.position.y, transform.position.z - zOffset);
		}
        if (Input.GetKey(KeyCode.D))
        {
            if (physicsController.IsRightWall()) {
                xOffset = 0;
                zOffset = 0;
            }
            transform.position = new Vector3(transform.position.x + zOffset, transform.position.y, transform.position.z - xOffset);
        }
		if (Input.GetKey(KeyCode.A))
		{
            if (physicsController.IsLeftWall()) {
                xOffset = 0;
                zOffset = 0;
            }
            transform.position = new Vector3(transform.position.x - zOffset, transform.position.y, transform.position.z + xOffset);
		}

		if (health <= 0)
		{
			//gameObject.SetActive(false);
		}

        rb.velocity = Vector3.zero;
	}

    private void FixedUpdate()
    {
        
    }

}
