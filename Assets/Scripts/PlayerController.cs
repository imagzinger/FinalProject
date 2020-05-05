using UnityEngine;
using System;
using System.Diagnostics;

public class PlayerController : MonoBehaviour
{
<<<<<<< Updated upstream
	public Rigidbody rb;
	public Transform t;
	public float degrees;
	public float zOffset;
	public float xOffset;

	public Collider head;
	public Collider body;
	public Collider mesh;
	public float health = 500.0f;
	public float speed = .1f;
	
=======
	[SerializeField] Rigidbody rb;
	[SerializeField] Transform t;
	float degrees;
	float zOffset;
	float xOffset;
	[SerializeField] Camera cam;
	[SerializeField] ObjectiveScript os;
	[SerializeField] Collider head;
	[SerializeField] Collider body;
	[SerializeField] Collider mesh;
	public float health = 500.0f;
	[SerializeField] float speed = .1f;
	[SerializeField] bool hasObjective = false;
	[SerializeField] GameObject crossHair;
	[SerializeField] GameObject snipeHair;
	private bool sniping = false;
>>>>>>> Stashed changes
	//[SerializeField] float eulerAngX;
	////[SerializeField] float eulerAngY;
	//[SerializeField] float eulerAngZ;
	float scroll = 1;
	[SerializeField] float zoomSpeed  = 100.0f; 
	void Update()
	{
		degrees = transform.localRotation.eulerAngles.y;
		zOffset = speed * (float)Math.Cos((degrees) / 180 * Math.PI);
		xOffset = speed * (float)Math.Sin((degrees) / 180 * Math.PI);
		scroll = Input.GetAxis("Mouse ScrollWheel") *50;
		cam.fieldOfView -= scroll;
		//UnityEngine.Debug.LogError(scroll);

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
		if (Input.GetKey(KeyCode.Space))
		{
			//t.position = new Vector3(transform.position.x - zOffset, transform.position.y, transform.position.z + xOffset);
			rb.AddForce(0.0f,10.0f,0.0f,ForceMode.VelocityChange);
		}
		//if (scroll > 0.0f)
		//{
		//	sniping = true;
		//	snipeHair.SetActive(sniping);
		//	crossHair.SetActive(!sniping);
		//}
		//if (scroll <= 0.0f)
		//{
		//	scroll = 0.0f;
		//	sniping = false;
		//	snipeHair.SetActive(sniping);
		//	crossHair.SetActive(!sniping);
		//}

		if (health <= 0)
		{
			gameObject.SetActive(false);
		}
	}
}
