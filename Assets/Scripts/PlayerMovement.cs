using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
	public Rigidbody rb;
	public Transform t;
	public Collider head;
	public Collider body;
	public Collider mesh;






	public float force = 10.0f;
	private float z;
	private float x;
	[SerializeField] float degrees;
	public float rotSpeed = 1.0f;
	public int iterationsOnSide = 0;
	public float flipSpeed = 5.0f;
	public float dynFriction = 0;
	public float statFriction = 0;
	[SerializeField] float eulerAngX;
	[SerializeField] float eulerAngY;
	[SerializeField] float eulerAngZ;

	void Update()
	{
		eulerAngX = transform.localRotation.eulerAngles.x;
		eulerAngY = transform.localRotation.eulerAngles.y;
		eulerAngZ = transform.localRotation.eulerAngles.z;// transform.localEulerAngles.z;
		degrees = transform.localRotation.eulerAngles.y;
		z = force * (float) Math.Cos( (degrees-90) / 180 * Math.PI);
		x = force * (float) Math.Sin( (degrees-90) / 180 * Math.PI);

		if (this.gameObject.tag == "p1") {
			if (Input.GetKey(KeyCode.W))
			{
				rb.AddForce(x * Time.deltaTime, 0, z * Time.deltaTime, ForceMode.VelocityChange);
			}
			if (Input.GetKey(KeyCode.S))
			{
				rb.AddForce(-x * Time.deltaTime, 0, -z* Time.deltaTime, ForceMode.VelocityChange);
			}
			if (Input.GetKey(KeyCode.D))
			{
				//degrees += (rotSpeed * Time.deltaTime);
				t.Rotate(0, 0, rotSpeed * Time.deltaTime);
			}
			if (Input.GetKey(KeyCode.A))
			{
				//degrees -= (rotSpeed * Time.deltaTime);
				t.Rotate(0,0, -rotSpeed * Time.deltaTime);
			}
			
		}
		if (this.gameObject.tag == "p2") {
			if (Input.GetKey(KeyCode.UpArrow))
			{
				rb.AddForce(x * Time.deltaTime, 0, z * Time.deltaTime, ForceMode.VelocityChange);
			}
			if (Input.GetKey(KeyCode.DownArrow))
			{
				rb.AddForce(-x * Time.deltaTime, 0, -z * Time.deltaTime, ForceMode.VelocityChange);
			}
			if (Input.GetKey(KeyCode.RightArrow))
			{
				degrees += (rotSpeed * Time.deltaTime);
				t.Rotate(0, 0, rotSpeed * Time.deltaTime);
			}
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				degrees -= (rotSpeed * Time.deltaTime);
				t.Rotate(0, 0, -rotSpeed * Time.deltaTime);
			} 
		}
		if (rb.position.y < -1f)
		{
			//GameObject.FindObjectOfType<GameManager>().EndGame();
		}
	}
}
