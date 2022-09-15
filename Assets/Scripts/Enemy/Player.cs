using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed;
    private float speed_move = 5f;

    [SerializeField]
    private Collider2D groundDedectionTrigger;

    [SerializeField]
    private ContactFilter2D groundContactFilter;

    private bool IsOnGround;
    private Collider2D[] groundHitDedectionResuts = new Collider2D[16];

    [SerializeField]
    private float fire_speed;
    private Vector2 fire_vec;



    // Update is called once per frame
    void Update()
    {
        UpdateIsOnGround();
        Playermove();
        Fire();
    }

    private void UpdateIsOnGround()
    {
       IsOnGround = groundDedectionTrigger.OverlapCollider(groundContactFilter, groundHitDedectionResuts) > 0;
    }

    private void Playermove()
    {
        speed = speed_move * Input.GetAxis("Horizontal");
        transform.Translate(speed * Time.deltaTime,0,0);
    }

    private void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject.FindGameObjectWithTag("Bullet");
        }
    }
}
