using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardBehavior : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Transform playerTransform;
    [SerializeField] UnityEngine.AI.NavMeshAgent agent;
    [SerializeField] float distance;

    public float health = 100.0f;
    public int healthPacks = 1;
    public float maxViewDistance = 100.0f;//maybe less???
    public float meleeDistance = 10.0f;
    public float hitDistance = 5.0f;
    public float meleeDmg = 20;
    public Vector3 start;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = player.Transform;
        start = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (InRange(maxViewDistance))
        {
            if (health < 20.0f)
                Heal();
            else if (InRange(meleeDistance))
                Melee();
            else
                Attack();
        }
        else
        {
            Return();
            Idle();
        }
    }

    // returns TRUE if the distance between the PLAYER and THIS is less than DIST otherwise returns false
    bool InRange(float dist)
    {
        return ( (((playerTransform.position.x - transform.position.x)
                * (playerTransform.position.x - transform.position.x))
                + ((playerTransform.position.y - transform.position.y) 
                * (playerTransform.position.y - transform.position.y))) < (dist* dist));
        
        
    }
    void Heal() 
    {
        if (healthPacks > 0)
        {
            Invoke("AddHealth", 1.0f);
            Invoke("AddHealth", 1.0f);
            Invoke("AddHealth", 1.0f);
        }
    }
    void AddHealth()
    {
        health += 20;
    }
    void Idle() 
    { 
        //some animation
    }
    void Return() 
    {
        agent.SetPosition(start);
    }
    void Melee() 
    {
        if (InRange(hitDistance))
        {
            StartCoroutine("PunchingPlayer");
        }
        else 
        {
            StopCoroutine("PunchingPlayer");
            MoveTo(playerTransform.position);
        }
    }
    IEnumerator PunchingPlayer()
    {
        yield return new WaitForSeconds(2.0f);
        //punch animation???
        player.health -= meleeDmg;
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
