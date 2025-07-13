using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class gunScript : MonoBehaviour
{
    //gun specs
    public int damage, magSize;
    public float cooldown, reloadTime, range;
    public bool rapidFire;
    int bulletsLeft;


    bool shooting, readyToShoot, Reloading;

    //reference
    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    //graphics 
    public GameObject bullethole;
    public TextMeshProUGUI ammo;
    
    public bool canDisplay = true;

    private void Start()
    {
        bulletsLeft = magSize;
        readyToShoot = true;
    }

    private void Update()
    {
        if (canDisplay == true)
        {
            PlayerInput();
            ammo.SetText(bulletsLeft + "/" + magSize);
        }
    }

    private void PlayerInput()
    {
        if (rapidFire) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKey(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magSize && !Reloading) Reload();

        //shooting
        if (readyToShoot && shooting && !Reloading && bulletsLeft > 0) Fire();
    }
    private void Reload()
    {
        Reloading = true;
        Invoke("ReloadDelay", reloadTime);
    }
    private void ReloadDelay()
    {
        bulletsLeft = magSize;
        Reloading = false;

    }
    private void Fire()
    {
        readyToShoot = false;

        //raycasting
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out rayHit, range, whatIsEnemy))
        {
            Debug.Log(rayHit.collider);
            if (rayHit.collider.CompareTag("Enemy"))
            {
                rayHit.collider.GetComponent<ShootingAi>().TakeDamage(damage);
            }

        }

        //Instantiate(bullethole, rayHit.point, Quaternion.Euler(0,180,0));

        bulletsLeft--;
        Invoke("checkCooldown", cooldown);
        
    }
    private void checkCooldown()
    {
        readyToShoot = true;
    }


}
