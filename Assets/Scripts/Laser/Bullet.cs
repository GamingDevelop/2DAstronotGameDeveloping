using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rigidBody2D;

    [SerializeField]
    private CircleCollider2D groundDedectionTrigger;

    [SerializeField]
    private ContactFilter2D groundContactFilter;

    private bool IsOnGround;
    private Collider2D[] groundHitDedectionResuts = new Collider2D[16];

    private PlayerAimWeapon paw;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        rigidBody2D.velocity = transform.right *speed;

    }

    private void Update()
    {
        BulletHit();
    }
    void onTriggerStay2D(Collider hitInfo)
    {
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }

    private void BulletHit()
    {
        IsOnGround = groundDedectionTrigger.OverlapCollider(groundContactFilter, groundHitDedectionResuts) > 0;
        Debug.Log(IsOnGround);
        if (IsOnGround == true)
        {
            Destroy(GameObject.FindGameObjectWithTag("Bullet"));
        }
    }
    
}

