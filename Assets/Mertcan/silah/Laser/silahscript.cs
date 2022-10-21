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

    public hareket hareket;

    public Vector2 silahhareket;
    public Transform el;
    public GameObject silah;
    private SpriteRenderer sr;
    private SpriteRenderer hareketsr;
    private Transform tr;
    public float offset;

    void shoot()
    {
       GameObject BulletIns =  Instantiate(bullet,shootpoint.position, shootpoint.rotation);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.right * bulletspeed);
        Destroy(BulletIns, 3);
    }

    private void Start()
    {
      sr = silah.GetComponent<SpriteRenderer>();
      tr = silah.GetComponent<Transform>();

      hareketsr = hareket.GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        Vector2 karakterkonum = hareket.transform.position;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)gun.position;
        float RotateZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(0f, 0f, RotateZ + offset);
        /*
        if (RotateZ < 89 && RotateZ > -89)
        {
            sr.transform.rotation = Quaternion.Euler(0f, 0, 0f);
            el.transform.position = new Vector2(karakterkonum.x + 0.30f, karakterkonum.y - 0.4f);
            silahhareket = mousePos - (Vector2)el.position;
           
        }

        else
        {
            sr.transform.rotation = Quaternion.Euler(0f, 180, 0f);
            el.transform.position = new Vector2(karakterkonum.x - 0.30f, karakterkonum.y - 0.4f);
            silahhareket = mousePos - (Vector2)el.position;
            
        }
        */



        if (RotateZ<89 && RotateZ>-89 || Input.GetKeyDown(KeyCode.A))
        {
            el.transform.position = new Vector2(karakterkonum.x + 0.30f, karakterkonum.y - 0.4f);
            //silahhareket = mousePos - (Vector2)el.position;
            sr.flipY = false;
            hareketsr.flipX = false;
        }
        
        else 
        {
            el.transform.position = new Vector2(karakterkonum.x - 0.30f, karakterkonum.y - 0.4f);
            //silahhareket = mousePos - (Vector2)el.position;
            sr.flipY = true;
            hareketsr.flipX = true;
        }
        



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
