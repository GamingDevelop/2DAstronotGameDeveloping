using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    [SerializeField]
    private Collider2D groundDedectionTrigger;

    [SerializeField]
    private ContactFilter2D groundContactFilter;

    private bool IsOnGround;
    private Collider2D[] groundHitDedectionResuts = new Collider2D[16];


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateIsOnGround();
        DestroyEnemies();
    }

    private void UpdateIsOnGround()
    {
        IsOnGround = groundDedectionTrigger.OverlapCollider(groundContactFilter, groundHitDedectionResuts) > 0;
    }

    private void DestroyEnemies()
    {
        if (IsOnGround == true)
        {
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }

}
