using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveScript : MonoBehaviour
{

    public bool isTaken = false;

    void OnTriggerEnter(Collider othe)
    {
        isTaken = true;
        gameObject.SetActive(false);
    }
}
