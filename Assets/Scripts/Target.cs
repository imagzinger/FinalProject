
using UnityEngine;

public class Target : MonoBehaviour
{

    public float health = 100f;


    public void TakeDamage(float amount) {

        health = health - amount;

 
        //animator.SetBool("Hit", hit);

        if (health <= 0f) {

            //animator.SetBool("Dead", isDead);
            //Destroy(gameObject);
        }
      
    
    }

}
