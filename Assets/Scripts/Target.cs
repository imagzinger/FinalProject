
using UnityEngine;

public class Target : MonoBehaviour
{

    public float health = 100f;

    public void TakeDamage(float amount) {

        health = health - amount;
        if (health <= 0f) {

            //DieAnimation();
            Destroy(gameObject);
        }

    }

}
