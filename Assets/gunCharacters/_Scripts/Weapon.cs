using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public float damage = 15;
    public float range = 100;

    public GameObject muzzleFlash;

    public Transform BulletSpawn;
    public AudioClip shotSFX;
    public AudioSource audioSource;

    public Camera cam;

    private float nextFire = 0;
    public float fireRate = 1;

    public GameObject hitEffect;
    public GameObject bloodEffect;

    public Canvas crosshair;

    public Text reloading;

    public int ammo = 30;
    public int maxAmmo = 30;
    public int ReloadTime = 3;
    public bool reload = false;
    public Text ammoText;

    public Animator animator;
    //public Animator CameraAnim;

    public float recoilTime = 0.1f;
    public float recoilIntens = 10.0f;
    public float spreadAngle = 30.0f;
    
    //public Enemy enemy;

    private void Start()
    {
        crosshair.enabled = true;
        reloading.enabled = false;
    }

    private void Update()
    {
        if (reload)
        {
            return;
        }

        else
        {
            if (ammo > 0)
            {
                if (Input.GetButton("Fire1") && Time.time > nextFire)
                {
                    nextFire = Time.time + 1f / fireRate;
                    //StartCoroutine(Recoil());
                    Shoot();
                    //CameraAnim.SetBool("Recoil", false);
                }

                if (Input.GetKeyDown(KeyCode.R) && ammo < 30)
                {
                    Reload();
                }
            }

            else
            {
                Reload();
            }
        }

        ammoText.text = ammo.ToString();


        if (Input.GetButton("Fire2"))
        {
            animator.SetBool("scoping", true);
            crosshair.enabled = false;
        }

        else if (Input.GetButtonUp("Fire2"))
        {
            animator.SetBool("scoping", false);
            crosshair.enabled = true;
        }

        if (Input.GetKey(KeyCode.F))
        {
            animator.SetTrigger("PressF");
            StartCoroutine(FTime());
        } 

    }

    void Shoot()
    {
        ammo--;
        audioSource.PlayOneShot(shotSFX);
        Instantiate(muzzleFlash, BulletSpawn.position, BulletSpawn.rotation);

        //CameraAnim.SetBool("Recoil", true);

        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {

            if (hit.collider.tag == "Enemy")
            {
                var enemy = hit.transform.GetComponent<Enemy>();

                if (enemy != null)
                {
                    //Debug.Log("hit!");
                    enemy.health -= 13;
                    GameObject effect = Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(effect, 0.3f);
                }
            }

            else if (hit.collider.tag == "mainEnemy")
            {
                var mainenemy = hit.transform.GetComponent<mainEnemy>();

                if (mainenemy != null)
                {
                    //Debug.Log("hit!");
                    mainenemy.health -= 13;
                    GameObject effect = Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(effect, 0.3f);
                }
            }

            else if (hit.collider.tag == "Turret")
            {
                var turret = hit.transform.GetComponent<TurretScript>();

                if (turret != null)
                {
                    //Debug.Log("hit!");
                    turret.health -= 20;
                    GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(impact, 2f);
                }
            }

            else if (hit.collider.tag == "wall_floor")
            {
                GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impact, 2f);
            }

        }

    }



    public void Reload()
    {
        reloading.enabled = true;
        StartCoroutine(ReloadTimeYield());
        reload = true;
    }

    IEnumerator ReloadTimeYield()
    {
        animator.SetBool("isReloading", true);
        yield return new WaitForSeconds(ReloadTime);
        reloading.enabled = false;
        ammo = maxAmmo;
        animator.SetBool("isReloading", false);
        reload = false;
    }

    IEnumerator FTime()
    {
        yield return new WaitForSeconds(5.22f);
        animator.SetTrigger("idle");
    }


}
