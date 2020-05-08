using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveScript : MonoBehaviour
{

    public bool isTaken = false;
    [SerializeField] Text objText;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            isTaken = true;
            objText.text = "Go Back";
            gameObject.SetActive(false);
        }
    }
}
