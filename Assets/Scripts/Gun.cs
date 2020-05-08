using System.Collections;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{

    [SerializeField] Camera fpsCam;
    //[SerializeField] Target target;
    public int ammo = 0;
    public int initAmmo = 15;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] Text UIbullets;
    [SerializeField] Transform player;
    public float recoilPower = .35f;
    public float recoilTime = .15f;
    [SerializeField] Slider ammoSlider;
    LookingDirection looking;
    Target target;
    RaycastHit hit;
    public float damage = 45f;
    public float range = 1000f;
    bool isReloading = false;
    bool canShoot = true;
    bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        looking = GetComponent<LookingDirection>();
        StartCoroutine(Reload());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && canShoot)
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R) && !isReloading) {
            StartCoroutine(Reload());
        }
    }

    void Shoot()
    {

        if (isReloading == true)
        {
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
                Debug.Log(target.name);
                target.TakeDamage(damage);
            }
        }
        StartCoroutine(Recoil());
    }

    IEnumerator Recoil()
    {
        looking.AddOffset(recoilPower);
        fpsCam.fieldOfView += 4 * recoilPower;
        canShoot = false;
        yield return new WaitForSeconds(recoilTime);
        looking.AddOffset(-recoilPower);
        fpsCam.fieldOfView -= 4 * recoilPower;
        canShoot = true;
        yield return new WaitForSeconds(recoilTime);
        looking.AddOffset(0f);

    }

    IEnumerator Reload()
    {
        UIbullets.text = "0";
        isReloading = true;
        ammoSlider.gameObject.SetActive(true);
        for (int i = 0; i < 45; i++)
        {
            yield return new WaitForSeconds(.1f);
            ammoSlider.value += 1;
        }
        ammo = initAmmo;
        UIbullets.text = ammo.ToString();
        isReloading = false;
        ammoSlider.gameObject.SetActive(false);
        ammoSlider.value = 0;
    }

    public void SetRecoil(float recoil) {
        recoilPower = recoil;
    }
}
