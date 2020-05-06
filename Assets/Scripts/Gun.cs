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
    [SerializeField] float recoilPower = .35f;
    [SerializeField] float recoilTime = .15f;
    [SerializeField] Slider ammoSlider;
    LookingDirection looking;
    RaycastHit hit;
    float damage = 45f;
    float range = 1000f;
    bool isReloading = false;
    bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        looking = GetComponent<LookingDirection>();
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
                target.TakeDamage(damage);
            }
        }
        StartCoroutine(Recoil());
    }

    IEnumerator Recoil()
    {
        looking.AddOffset(recoilPower);
        canShoot = false;
        yield return new WaitForSeconds(recoilTime);
        looking.AddOffset(-recoilPower);
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
        ammo = 15;
        UIbullets.text = ammo.ToString();
        isReloading = false;
        ammoSlider.gameObject.SetActive(false);
        ammoSlider.value = 0;
    }

    public void SetRecoil(float recoil) {
        recoilPower = recoil;
    }
}
