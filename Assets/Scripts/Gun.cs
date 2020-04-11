
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField] Camera fpsCam;
    RaycastHit hit;
    [SerializeField] Target target;
    float damage = 45f;
    float range = 1000f;

    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1")) {

            Shoot();
        
        }
    }

    
    void Shoot() {

        //shoots ray
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
            //returns true if ray is hit. If ray is hit, we need to check if enemy character was hit. If they were, then inflict damage;
            Debug.LogError("HIT");
            target = hit.transform.GetComponent<Target>();
            Debug.LogError(hit.transform.name);
            if (target != null) {
                Debug.LogError("NOT NULL");
                target.TakeDamage(damage);


            }


        }
    
       
    }


}
