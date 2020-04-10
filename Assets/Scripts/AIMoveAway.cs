using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;

public class AIMoveAway : MonoBehaviour
{
	[SerializeField] Transform playerT;
	[SerializeField] NavMeshAgent agent;
	private float distance;
	public float maxDistance = 10;
	public Vector3 start;
	public Vector3 running;
	public float xDiff;
	public float zDiff;

	void Start()
	{
		start = transform.position;
		running = start;
	}

	void Update()
	{
		//start = new Vector3(0.0f, 1.75f, 20.0f);
		float xP = playerT.position.x;
		float zP = playerT.position.z;
		float xC = transform.position.x;
		float zC = transform.position.z;
		xDiff = (xP - xC);
		zDiff = (zP - zC);
		float total = (xDiff * xDiff + zDiff * zDiff);

		distance =(float) Math.Sqrt((double)total);
		//distance = Math.Sqrt( (double) ((xP-xC)(xP-xC) + (yP-yC)(yP-yC)) );
		if (distance < maxDistance)
		{
			//move agent away from player in straight line
			//
			//running = running - new Vector3(5 * xDiff, 0,5 * zDiff);
			running.x = transform.position.x - 10*xDiff/distance;
			running.z = transform.position.z - 10*zDiff/distance;

			agent.SetDestination(running);
		}
		else 
		{
			agent.SetDestination(start);
			running = start;
		}
	}
}
