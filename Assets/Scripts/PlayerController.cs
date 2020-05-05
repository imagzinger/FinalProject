using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
	public Rigidbody rb;
	public float degrees;
	public float zOffset;
	public float xOffset;
    PhysicsController physicsController;
    [SerializeField] ObjectiveScript os;
    Camera camera;
	//public Collider head;
	//public Collider body;
	//public Collider mesh;
	public float health = 500.0f;
	public float speed = .1f;
	public bool hasObjective = false;
    private bool isCrouched = false;
    //[SerializeField] float eulerAngX;
    ////[SerializeField] float eulerAngY;
    //[SerializeField] float eulerAngZ;

    void Start()
    {
        physicsController = GetComponent<PhysicsController>();
        rb = GetComponent<Rigidbody>();
        camera = Camera.main;
    }

    void Update()
    {
        //eulerAngX = transform.localRotation.eulerAngles.x;
        //eulerAngY = transform.localRotation.eulerAngles.y;
        //eulerAngZ = transform.localRotation.eulerAngles.z;// transform.localEulerAngles.z;
        degrees = transform.localRotation.eulerAngles.y;
        zOffset = speed * (float)Math.Cos((degrees) / 180 * Math.PI);
        xOffset = speed * (float)Math.Sin((degrees) / 180 * Math.PI);

        //Debug.Log("X Offset: " + xOffset + ", Z Offset: " + zOffset);
        // Debug.Log("forward: " + transform.forward);

        //crouch
        if (Input.GetKey(KeyCode.LeftControl)) {
            if (!isCrouched)
            {
                isCrouched = true;
                camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y - 1f, camera.transform.position.z);
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftControl)) {
            if (isCrouched) {
                isCrouched = false;
                camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y + 1f, camera.transform.position.z);
            }
        }

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
            if (physicsController.IsBackWall())
            {
                xOffset = 0;
                zOffset = 0;
            }
            transform.position = new Vector3(transform.position.x - xOffset, transform.position.y, transform.position.z - zOffset);
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (physicsController.IsRightWall())
            {
                xOffset = 0;
                zOffset = 0;
            }
            transform.position = new Vector3(transform.position.x + zOffset, transform.position.y, transform.position.z - xOffset);
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (physicsController.IsLeftWall())
            {
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
        hasObjective = os.isTaken;
	}
}
