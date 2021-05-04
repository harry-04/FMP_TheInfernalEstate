using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public int maxAmmo = 60;
    private int currentAmmo;
    public float reloadTime = 1f;



    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;


    void Start()
    {
        if (currentAmmo == -1)
            currentAmmo = maxAmmo;
    }


    // Update is called once per frame
    void Update()
    {
        if (currentAmmo <= 0)
        {
            Reload();
            return;
        }


        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        
    }


    void Shoot()
    {
        muzzleFlash.Play();

        currentAmmo--;
        

        RaycastHit hitInfo;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, range))
        {
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();

            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            Instantiate(impactEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));


        }

    }


    void Reload()
    {
        Debug.Log("Reloading...");
        currentAmmo = maxAmmo;
    }

}
