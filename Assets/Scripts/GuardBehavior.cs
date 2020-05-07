using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardBehavior : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] Transform playerTransform;
    [SerializeField] UnityEngine.AI.NavMeshAgent agent;
    [SerializeField] Target target;
    [SerializeField] float distance;
    [SerializeField] Transform objective;
    [SerializeField] ObjectiveScript objscript;
    float fovAngle = 130;
    private Vector3 objectivePos;
    private bool punching;
    private bool shooting;
    private int frames = 0;
    //public float target.health = 100.0f;
    public int healthPacks = 1;
    public float maxViewDistance = 500.0f;//maybe less???
    public float meleeDistance = 10.0f;
    public float hitDistance = 25.0f;
    public float meleeDmg = 100;
    public Vector3 start;
    public Vector3 start2;

    // Start is called before the first frame update
    void Start()
    {
        //playerTransform = player.Transform;
        start = transform.position;
        start2 = new Vector3(transform.position.x+30, transform.position.y, transform.position.z);
        objectivePos = objective.position;
        agent.speed = 10.0f;
        objscript = GameObject.FindGameObjectWithTag("objective").GetComponent<ObjectiveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.LogError(objscript.isTaken);
        if (objscript.isTaken || InRange(maxViewDistance))
        {
            

            //MoveTo(playerTransform.position);
            if (InRange(maxViewDistance))
            {
                MoveTo(playerTransform.position);
                //Debug.LogError(objscript.isTaken);
                if (target.health < 20.0f)
                    Heal();
                else if (InRange(meleeDistance) && PlayerInSight())
                {
                    //Debug.LogError("IN RANGEEEEE");
                    Invoke("Melee", 2.0f);
                }
                else
                    Attack();
            }
            else if (objscript.isTaken)
            {
                //Debug.LogError(objectivePos);
                MoveTo(objectivePos);
            }
        }
        else
        {
            Return();
            Idle();
            //StartCoroutine("Idle");
        }
        frames++;
    }

    // returns TRUE if the distance between the PLAYER and THIS is less than DIST otherwise returns false
    bool InRange(float dist)
    {
        bool inRange = ((((playerTransform.position.x - transform.position.x)
                * (playerTransform.position.x - transform.position.x))
                + ((playerTransform.position.y - transform.position.y)
                * (playerTransform.position.y - transform.position.y))) < (dist * dist));
        //Debug.LogError("ranging of " + dist + " "+ inRange);
        return inRange;
        
        
    }
    void Heal() 
    {
        float currentHp = target.health;
        if (healthPacks > 0)
        {
            healthPacks--;
            Invoke("AddHealth", 1.0f);
            if (target.health < currentHp)
                return;
            Invoke("AddHealth", 1.0f);
            if (target.health < currentHp)
                return;
            Invoke("AddHealth", 1.0f);

        }
    }
    void AddHealth()
    {
        target.health += 20;
    }
    void Idle() 
    {
        agent.destination = start;
        agent.destination = start2;
        //MoveTo(start);
        //yield return new WairForSeconds(5.0f);
        //MoveTo(start2);
        //some animation
    }
    void Melee() 
    {
        //player.target.health -= meleeDmg;
        if (InRange(hitDistance) && !punching)
        {
            punching = true;
            StartCoroutine("PunchingPlayer");
        }
        else if (punching) { }
        else
        {
            StopCoroutine("PunchingPlayer");
            punching = false;
            MoveTo(playerTransform.position);
        }
    }
    void MoveTo(Vector3 vector)
    {
        //Debug.LogError("Setting destination:"+vector);
        agent.SetDestination(vector);
    }
    void Return()
    {
        MoveTo(start);
    }
    IEnumerator PunchingPlayer()
    {
        punching = true;
        
        //Debug.LogError("punch");
        //punch animation???
        player.health -= meleeDmg;
        yield return new WaitForSeconds(2.0f);
        punching = false;
    }
    void Attack()
    {
        if (frames % 120 == 0)
        {
            Shoot();
        }
        //shoot at the player
        //if (InRange(meleeDistance * 2))
        //{ 
        //    //back up
        //    //animation walkBackwards
        //    if (InRange(meleeDistance))
        //    { 
        //        //animation melee?
        //    }

        //}
        //gun.Shoot();
    }
    void Shoot()
    {

        //shooting = true;
        //yield return new WaitForSeconds(1.0f);
       // Debug.Log(PlayerInSight());
        if (PlayerInSight())
        {
            player.health -= 25;
        }
        
        //shooting = false;
    }

    //sends a ray from enemy to player, and returns whether or not they are in view
    bool PlayerInSight()
    {
        
        Vector3 direction = player.transform.position - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);

        if (angle < fovAngle * 0.5f)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction.normalized, out hit, maxViewDistance))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    return true;
                }
            }
        }

        return false;
    }

}
