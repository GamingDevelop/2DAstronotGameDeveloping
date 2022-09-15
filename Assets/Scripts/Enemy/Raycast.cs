﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField]
    private Transform tr;
    private Transform tr_p;
    private Rigidbody2D rb;

    [SerializeField]
    private float speed = 0.3f;
    [SerializeField]
    private Vector2 start;
    [SerializeField]
    private Vector2 stop;
    [SerializeField]
    private float oldPosition;


    [SerializeField]
    private Collider2D groundDedectionTrigger;

    [SerializeField]
    private ContactFilter2D groundContactFilter;

    private bool IsOnGround;
    private Collider2D[] groundHitDedectionResuts = new Collider2D[16];

    [SerializeField]
    private int count = 0;

    [SerializeField]
    private SpriteRenderer sp;

    [SerializeField]
    private Animator anim;

    void Start()
    {
        tr = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
        tr_p = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>();
    }

    
    void Update()
    {
        UpdateIsOnGround();
        focus();
    }

    private void focus()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.left) * 5f, Color.red);   
        RaycastHit2D hit = Physics2D.Raycast(transform.position,transform.TransformDirection(Vector2.left),5f);
        if (IsOnGround == true)
        {
            count++;
        }
        if (count==0)
        {
            EnemyMove();
        }
        else{
            EnemyFollow();
            anim.SetBool("faz", true);

        }
    }

    private void EnemyMove()
    {
        transform.position = Vector2.Lerp(start, stop, Mathf.PingPong(Time.time * speed, 1.0f));
        if (tr.position.x > oldPosition)
        {
            sp.flipX = true;

        }
        else if(tr.position.x < oldPosition)
        {

            sp.flipX = false;
        }
        oldPosition = transform.position.x;
    }

    private void EnemyFollow()
    {
        Vector3 targetposition = new Vector3(tr_p.position.x,gameObject.transform.position.y,tr_p.position.x);
        transform.position = Vector2.MoveTowards(transform.position, targetposition, 1f*Time.deltaTime);
    }

    private void UpdateIsOnGround()
    {
        IsOnGround = groundDedectionTrigger.OverlapCollider(groundContactFilter, groundHitDedectionResuts) > 0;
        Debug.Log("oluyor mu" + IsOnGround);
    }
}