using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    [SerializeField] GameObject levelManager;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            Debug.Log("works");
            if (other.GetComponent<PlayerController>().hasObjective)
            {
                levelManager.GetComponent<LevelManager>().Complete();
            }
        }
    }
}
