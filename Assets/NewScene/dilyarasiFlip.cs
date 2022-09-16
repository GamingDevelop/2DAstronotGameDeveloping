using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dilyarasiFlip : MonoBehaviour
{
    public Transform tr;
    public Transform tr_p;
    public SpriteRenderer sr;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFlip();
    }

    private void UpdateFlip()
    {
        if (tr.position.x < tr_p.position.x)
        {
            sr.flipX = true;
        }
        else if (tr.position.x > tr_p.position.x)
        {
            sr.flipX = false;
        }
    }

}
