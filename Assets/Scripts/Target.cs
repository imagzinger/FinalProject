
using UnityEngine;

public class Target : MonoBehaviour
{

    public float health = 100f;
    private bool isDead = false;
    private bool hit = false;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float amount) {

        health = health - amount;

        hit = true;
        //animator.SetBool("Hit", hit);

        if (health <= 0f) {

            isDead = true;
            animator.SetBool("Dead", isDead);
            Destroy(gameObject);
        }
        isDead = false;
        hit = false;
    }

}
