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
    [SerializeField] ObjectScript objscript;
    private bool punching;
    //public float target.health = 100.0f;
    public int healthPacks = 1;
    public float maxViewDistance = 200.0f;//maybe less???
    public float meleeDistance = 50.0f;
    public float hitDistance = 25.0f;
    public float meleeDmg = 100;
    public Vector3 start;
    // Start is called before the first frame update
    void Start()
    {
        //playerTransform = player.Transform;
        start = transform.position;
        agent.speed = 50.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //MoveTo(playerTransform.position);
        if (InRange(maxViewDistance))
        {
            MoveTo(playerTransform.position);
            //Debug.LogError("i can see you");
            if (target.health < 20.0f)
                Heal();
            else if (InRange(meleeDistance))
            {
                //Debug.LogError("IN RANGEEEEE");
                Invoke("Melee", 2.0f);
            }
            else if (objscript.isTaken)
            {
                MoveTo(objective.Transform.position);
            }
            else
                Attack();
        }
        else
        {
            MoveTo(start);
            Idle();
        }
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
        agent.SetDestination(vector);
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
        //shoot at the player
        if (InRange(meleeDistance * 2))
        { 
            //back up
            //animation walkBackwards
            if (InRange(meleeDistance))
            { 
                //animation melee?
            }

        }
        //gun.Shoot();
    }

}
