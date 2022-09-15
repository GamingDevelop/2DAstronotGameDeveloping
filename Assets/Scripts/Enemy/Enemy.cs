using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scripts : MonoBehaviour
{
    //Enemy Property
    public float damage;
    public float health;

    //General identify
    public Collider2D coll;
    public ContactFilter2D contact;
    public Collider2D PlayerColl;
    public bool control;

    void Start()
    {
        coll = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Collider2D>();
        contact = GameObject.FindGameObjectWithTag("Player").GetComponent<ContactFilter2D>();
        PlayerColl = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        deneme();
    }

    public  void giveDamage(float damage)
    {
        damage = this.damage;


    }

    public void getDamage(float damage)
    {
        if (health-damage > 0)
        {
            health = health - damage;
        }
        else if (health - damage <= 0)
        {

        }
    }

    public void deneme()
    {
    control = coll.IsTouching(PlayerColl);
    }

}
