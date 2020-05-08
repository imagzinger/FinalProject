
using System.Globalization;
using System.Security.Cryptography;
using UnityEngine.UI;
using UnityEngine;

public class Target : MonoBehaviour
{
    //public int deaths = 0;
    public float health = 100f;
    [SerializeField] Transform objective;
    [SerializeField] PlayerController pc;
    [SerializeField] Text numKills;
    public void TakeDamage(float amount) {

        health = health - amount;


        //animator.SetBool("Hit", hit);

        if (health <= 0f) {

            //DieAnimation();
           
            //deaths++;
            pc.kills++;
            numKills.text = pc.kills.ToString();
            gameObject.SetActive(false);
            Invoke("SpawnNew", 10f);
        }


    }

    void SpawnNew()
    {
        health = 100f;
        gameObject.transform.position = objective.position;
        gameObject.SetActive(true);
    }

}
