using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patroller : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] List<Vector3> locations;
    [SerializeField] float fovAngle = 100;
    [SerializeField] float detectionDistance = 20;
    [SerializeField] float alertDistance = 50;
    [SerializeField] float currentHealth = 100;
    [SerializeField] float maxHealth = 100;
    [SerializeField] float fleeThreshhold = 30;
    GameObject player;
    bool finishedSearching;
    int nextLocation;
    int previousLocation;


    // Start is called before the first frame update
    void Start()
    {
        nextLocation = 0;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool PlayerInSight()
    {
        Vector3 direction = player.transform.position - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);

        if (angle < fovAngle * 0.5f)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, detectionDistance))
            {
                if (hit.collider.gameObject == player)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public void Return()
    {
        agent.SetDestination(locations[previousLocation]);
    }

    public void WalkPath()
    {
        agent.SetDestination(locations[nextLocation]);
        previousLocation = nextLocation;
        if (nextLocation == locations.Count - 1)
        {
            nextLocation = 0;
        }
        else
        {
            nextLocation++;
        }

    }

    public bool AtDestination()
    {

        if (Vector3.Distance(transform.position, locations[previousLocation]) < 0.2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator Search()
    {
        finishedSearching = false;
        transform.Rotate(new Vector3(0, 90, 0));
        yield return new WaitForSeconds(3);
        transform.Rotate(new Vector3(0, 180, 0));
        yield return new WaitForSeconds(3);
        finishedSearching = true;
    }

    public bool FinishedSearching()
    {
        return finishedSearching;
    }

    public void Alert()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) <= alertDistance)
            {
                enemy.GetComponent<PatrolFSM>().SetAttack();
            }
        }
    }

    public void Attack()
    {
        agent.SetDestination(player.transform.position);
        //will add more later (out of scope for project 4)
    }

    public bool HealthLow()
    {
        if (currentHealth / maxHealth < .3)
        {
            return true;
        }
        return false;
    }

    public void Flee()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - player.transform.position);
        Vector3 runTo = transform.position + (transform.forward * (fleeThreshhold + 5));
        agent.SetDestination(runTo);
    }

    public bool FinishedFleeing()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > fleeThreshhold)
        {
            return true;
        }

        return false;
    }

}
