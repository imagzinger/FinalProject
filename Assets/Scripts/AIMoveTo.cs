using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;

public class AIMoveTo : MonoBehaviour
{
	[SerializeField] Transform playerT;
	[SerializeField] NavMeshAgent agent;
	[SerializeField] float distance;
	public float maxDistance = 10;
	public Vector3 start;
	//public Vector3 running;

	void Start()
	{
		start = transform.position;
	}

	void Update()
	{
		//start = transform.positionnew Vector3(0.0f, 1.75f, 20.0f);
		//running = new Vector3(20.0f, 1.75f, 0.0f);
		float xP = playerT.position.x;
		float yP = playerT.position.y;
		float xC = transform.position.x;
		float yC = transform.position.y;
		float xDiff = (xP - xC);
		float yDiff = (yP - yC);
		float total = (xDiff * xDiff + yDiff * yDiff);

		distance =(float) Math.Sqrt((double)total);
		//distance = Math.Sqrt( (double) ((xP-xC)(xP-xC) + (yP-yC)(yP-yC)) );
		if (distance < maxDistance)
		{
			//move agent
			//
			agent.SetDestination(playerT.position);
		}
		else 
		{
			agent.SetDestination(start);
		}
	}
}
