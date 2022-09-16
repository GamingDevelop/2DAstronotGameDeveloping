using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dilyarasi : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sr;

    [SerializeField]
    private Transform tr;

    [SerializeField]
    private Transform tr_p;

    [SerializeField]
    private Collider2D groundDedectionTrigger;

    [SerializeField]
    private ContactFilter2D groundContactFilter;

    private bool IsOnGround;
    private Collider2D[] groundHitDedectionResuts = new Collider2D[16];

    [SerializeField]
    private Rigidbody2D rb;



    void Update()
    {
        UpdateEnemyFlying();
        UpdateEnemyDedection();
    }

    private void UpdateEnemyFlying() {
        if (tr.position.x < tr_p.position.x)
        {
            sr.flipX = true;
        }
        else if (tr.position.x > tr_p.position.x)
        {
            sr.flipX = false;
        }
    }

    private void UpdateEnemyDedection()
    {
        IsOnGround = groundDedectionTrigger.OverlapCollider(groundContactFilter, groundHitDedectionResuts) > 0;
        Debug.Log(IsOnGround);
        if (IsOnGround == true)
        {
            rb.velocity = new Vector3(10, 0, 0);
        }
    }
}
