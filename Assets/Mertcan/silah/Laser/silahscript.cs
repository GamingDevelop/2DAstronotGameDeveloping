using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class silahscript : MonoBehaviour
{
    public Transform gun;
    Vector2 direction;

    
    public GameObject bullet;
    public float bulletspeed;
    public Transform shootpoint;


    public float fireRate;
    private float ReadyForNextShoot;

    public Animator gunanimator;

    void FaceMouse()
    {
        gun.transform.right = direction;
    }

    void shoot()
    {
       GameObject BulletIns =  Instantiate(bullet,shootpoint.position, shootpoint.rotation);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.right * bulletspeed);
        Destroy(BulletIns, 3);
        gunanimator.SetTrigger("Shoot");
    }


    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)gun.position;
        FaceMouse();

        //kurþun
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time>ReadyForNextShoot)
            {
                ReadyForNextShoot = Time.deltaTime + 1 / fireRate;
                shoot();
            }

        }

    }

}
