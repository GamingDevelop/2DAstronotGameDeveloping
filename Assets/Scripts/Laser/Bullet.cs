using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rigidBody2D;
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        rigidBody2D.velocity = transform.right *speed;

    }
    void onTriggerStay2D(Collider hitInfo)
    {
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }

    // Update is called once per frame
    
}

