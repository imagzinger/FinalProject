
using System.Security.Cryptography;
using UnityEngine;

public class Target : MonoBehaviour
{

    public float health = 100f;
    [SerializeField] Transform objective;
    public void TakeDamage(float amount) {

        health = health - amount;
        if (health <= 0f) {

            //DieAnimation();
            gameObject.SetActive(false);
            Invoke("SpawnNew",10f);
        }

    }

    void SpawnNew()
    {
        gameObject.transform.position = objective.position;
        gameObject.SetActive(true);
    }

}
