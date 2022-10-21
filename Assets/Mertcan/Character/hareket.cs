using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hareket : MonoBehaviour
{
    //hareket
    public float hareketHizi=20;
    public float hareketHiziyukari = 20;
    public float hiz;

    //z�plama
    private Rigidbody2D rigid;
    public float jumpForce;
    private bool isJump;
    private bool isJumpforce;


    //y�n de�i�tirme
    private SpriteRenderer sr;


    //dash
    public float dashzamaninibaslat;
    private float suankidashzamani;
    private bool dashyap�yor;
    private float dashyonu;
    public float cd;
    private float suankicd;

  
    private void Start()
    {
        //z�plama
        rigid = GetComponent<Rigidbody2D>();

        //y�n de�i�tirme
        sr = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        //hareket
        hiz = hareketHizi * Input.GetAxis("Horizontal");
        transform.Translate(hiz * Time.deltaTime,0,0);


        //z�plama
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isJump == false)
            {
                rigid.AddForce(Vector2.up * jumpForce);
                isJump = true;
            }

        }

        /*
        //y�n de�i�tirme
        if (hiz<0)
        {
            sr.flipX = true;
        }
        else if(hiz>0)
        {
            sr.flipX = false;
        }
        */

        //dash
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dashyap�yor = true;
            suankidashzamani = dashzamaninibaslat;
            dashyonu = (int)hiz;
            suankicd = cd;
        }

        
        if (dashyap�yor)
        {
            hareketHizi = 200;
            suankidashzamani -= Time.deltaTime;

            if (suankidashzamani<=0)
            {
                hareketHizi = 20;
                dashyap�yor = false;
            }

        }
        RecoilPlayer();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //z�plama
        if (collision.gameObject.CompareTag("Zemin"))
        {
            isJump = false;
            
        }


    }

    private void RecoilPlayer()
    {
        if (Input.GetMouseButtonDown(0) && sr.flipX == false)
        {
            Debug.Log("a");
            rigid.AddForce(Vector2.left * 400f);
        }
        else if (Input.GetMouseButtonDown(0) && sr.flipX == true)
        {
            rigid.AddForce(Vector2.right * 400f);
        }
    }

}
