using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardBehavior : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] float distance;

    public float health = 100;
    public float maxViewDistance = 100;//maybe less???
    public float meleeDistance = 10;
    // Start is called before the first frame update
    void Start()
    {
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
    bool InRange(int dist)
    {
        return ( (((playerTransform.position.x - transform.position.x)
                * (playerTransform.position.x - transform.position.x))
                + ((playerTransform.position.y - transform.position.y) 
                * (playerTransform.position.y - transform.position.y))) < (dist* dist);
        
        
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
