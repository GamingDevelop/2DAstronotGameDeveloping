using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //Enemy Property
    public float damage;
    public float health;
    public PlayerManager PM;

    // Update is called once per frame
    void Update()
    {

    }
    
    public void getDamage(float damage)
    {
        if (health - PM.damage_p > 0)
        {
            health = health - damage;
        }
        else if (health - PM.damage_p <= 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("Enemy"),0.5f);
        }
    }
}
