using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{

    [SerializeField] Camera fpsCam;
    [SerializeField] Target target;
    [SerializeField] int ammo = 15;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] Text UIbullets;
    [SerializeField] Transform player;
    LookingDirection looking;
    RaycastHit hit;
    float damage = 45f;
    float range = 1000f;
    bool isReloading = false;

    // Start is called before the first frame update
    void Start()
    {
        looking = GetComponent<LookingDirection>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();       
        }
    }
  
    void Shoot() {

         if (isReloading == true) {
             return;
         }
         muzzleFlash.Play();
         ammo--;
         UIbullets.text = ammo.ToString();
         if (ammo == 0)
         {
            StartCoroutine(Reload());       
         }
         if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range) == true)
         {
            target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
              target.TakeDamage(damage);
            }
         }

    }

    IEnumerator Reload() {

        UIbullets.text = "Reloading...";
        isReloading = true;
        yield return new WaitForSeconds(4.5f);
        ammo = 15;
        UIbullets.text = ammo.ToString();
        isReloading = false;
    }
} 
