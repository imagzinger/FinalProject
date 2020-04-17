using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolFSM : MonoBehaviour
{

    State currentState = State.WALK;

    Patroller patroller;

    enum State
    {
        WALK,
        SEARCH,
        ALERT,
        ATTACK,
        FLEE,
        RETURN
    }

    // Start is called before the first frame update
    void Start()
    {
        patroller = gameObject.GetComponent<Patroller>();
        patroller.WalkPath();
    }

    // Update is called once per frame
    void Update()
    {

        if (currentState == State.WALK)
        {
            if (patroller.PlayerInSight())
            {
                currentState = State.ALERT;
                patroller.Alert();
            }
            if (patroller.AtDestination())
            {
                currentState = State.SEARCH;
                patroller.StartCoroutine("Search");
            }
        }
        else if (currentState == State.SEARCH)
        {
            if (patroller.PlayerInSight())
            {
                patroller.StopCoroutine("Search");
                currentState = State.ALERT;
                patroller.Alert();
            }
            if (patroller.FinishedSearching())
            {
                currentState = State.WALK;
                patroller.WalkPath();
            }
        }
        else if (currentState == State.ALERT)
        {
            StartCoroutine("Waitsec");
            currentState = State.ATTACK;
            patroller.Attack();

        }
        else if (currentState == State.ATTACK)
        {
            if (patroller.HealthLow())
            {
                currentState = State.FLEE;
                patroller.Flee();
            }
            else
            {
                patroller.Attack();
            }
        }
        else if (currentState == State.FLEE)
        {
            if (patroller.FinishedFleeing())
            {
                currentState = State.RETURN;
                patroller.Return();
            }
            else
            {
                patroller.Flee();
            }
        }
        else if (currentState == State.RETURN)
        {
            if (patroller.PlayerInSight())
            {
                currentState = State.ALERT;
                patroller.Alert();
            }
            if (patroller.AtDestination())
            {
                currentState = State.SEARCH;
                patroller.StartCoroutine("Search");
            }
        }
    }

    public void SetAttack()
    {
        currentState = State.ATTACK;
        patroller.Attack();
        Debug.Log("HELLO");
    }

    IEnumerator Waitsec()
    {
        yield return new WaitForSeconds(1);
    }

}

