using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
	public Rigidbody rb;
	public Transform t;
	public float degrees;
	public float zOffset;
	public float xOffset;
	[SerializeField] ObjectiveScript os;
	public Collider head;
	public Collider body;
	public Collider mesh;
	public float health = 500.0f;
	public float speed = .1f;
	public bool hasObjective = false;
	//[SerializeField] float eulerAngX;
	////[SerializeField] float eulerAngY;
	//[SerializeField] float eulerAngZ;
	void Update()
	{
		//eulerAngX = transform.localRotation.eulerAngles.x;
		//eulerAngY = transform.localRotation.eulerAngles.y;
		//eulerAngZ = transform.localRotation.eulerAngles.z;// transform.localEulerAngles.z;
		degrees = transform.localRotation.eulerAngles.y;
		zOffset = speed * (float)Math.Cos((degrees) / 180 * Math.PI);
		xOffset = speed * (float)Math.Sin((degrees) / 180 * Math.PI);

		if (Input.GetKey(KeyCode.W))
		{
			t.position = new Vector3(transform.position.x + xOffset, transform.position.y, transform.position.z + zOffset);
		}
		if (Input.GetKey(KeyCode.S))
		{
			t.position = new Vector3(transform.position.x - xOffset, transform.position.y, transform.position.z - zOffset);
		}
		if (Input.GetKey(KeyCode.D))
		{
			t.position = new Vector3(transform.position.x + zOffset, transform.position.y, transform.position.z - xOffset);
		}
		if (Input.GetKey(KeyCode.A))
		{
			t.position = new Vector3(transform.position.x - zOffset, transform.position.y, transform.position.z + xOffset);
		}

		if (health <= 0)
		{
			gameObject.SetActive(false);
		}
		hasObjective == os.isTaken;
	}
}
