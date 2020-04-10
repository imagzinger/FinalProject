using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;

public class AIHerd : MonoBehaviour
{
	[SerializeField] Transform playerT;
	[SerializeField] NavMeshAgent agent;
	[SerializeField] Transform[] enemies;
	[SerializeField] int numOfEnemies = 3;
	private float distance;
	public float maxDistance = 10;
	static public Vector3 start;
	public Vector3 destination;
	[SerializeField] Transform nearestEnemy;
	public Vector3 position1;
	public Vector3 position2;

	void Start()
	{
		start = transform.position;
		position1 = new Vector3(start.x + 3, start.y, start.z);
		position2 = new Vector3(start.x - 3, start.y, start.z);
	}
	
	void Update()
	{
		//enemies = new Transform[numOfEnemies];
		FindNearestEnemy();
		float xP = playerT.position.x;
		float zP = playerT.position.z;
		float xC = transform.position.x;
		float zC = transform.position.z;
		float xE = nearestEnemy.position.x;
		float zE = nearestEnemy.position.z;
		float xDiff = (xP - xC);
		float zDiff = (zP - zC);
		float total = (xDiff * xDiff + zDiff * zDiff);

		distance =(float) Math.Sqrt((double)total);

		if (distance < maxDistance)
		{
			xDiff = (xP - xE);
			zDiff = (zP - zE);
			//total = (xDiff * xDiff + zDiff * zDiff);
			destination = playerT.position;
			destination.x += xDiff / distance;
			destination.z += zDiff / distance;

			agent.SetDestination(destination);
		}
		else
		{
			//agent.SetDestination(start);
			agent.SetDestination(position1);
			Patrol();
		}
	}

	void FindNearestEnemy()
	{
		float closestDist = 10000.0f;
		for (int i = 0; i < enemies.Length; i++)
		{
			float xP = playerT.position.x;
			float zP = playerT.position.z;
			float xC = enemies[i].position.x;
			float zC = enemies[i].position.z;
			float xDiff = (xP - xC);
			float zDiff = (zP - zC);
			float total = (xDiff * xDiff + zDiff * zDiff);

			distance = (float)Math.Sqrt((double)total);
			if (distance < closestDist)
			{
				closestDist = distance;
				nearestEnemy = enemies[i];
			}
		}
	}

	void Patrol()
	{

		//if (transform.position.z == position1.z)// false every time why?
		//{
			agent.SetDestination(position2);
		//}
		//else if(transform.position.z == position2.z)
		//{
			agent.SetDestination(position1);
		//}
	}
}
