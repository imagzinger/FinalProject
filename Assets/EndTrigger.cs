using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    [SerializeField] GameObject endScene;
    void OnCollisionEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            if (other.GetComponent<PlayerController>().hasObjective)
            {
                endScene.SetActive(true);
            }
        }
    }
}
