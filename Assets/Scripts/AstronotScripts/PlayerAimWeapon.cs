using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{
    public  Transform firePoint;
    public GameObject bulletPrefab;

    private Transform aimTransform;
    Vector3 aimDirection;
    Vector3 mousePosition;
    // Start is called before the first frame update
    void Awake()
    {
        aimTransform = transform.Find("Aim");
    }

    // Update is called once per frame
    void Update()
    {   
        SetMousePosition();
        CheckInput();
    }


    private void CheckInput(){

        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void SetMousePosition(){
        mousePosition  = GetMouseWorldPosition();
        aimDirection  = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0,0, angle);
    } 

    private void Shoot(){
            Instantiate(bulletPrefab,firePoint.position , firePoint.rotation);
    }




public static Vector3 GetMouseWorldPosition () {
    Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition,Camera.main);
    vec.z = 0f ;
    return vec ;
}
public static Vector3 GetMouseWorldPositionWithZ(){

    return GetMouseWorldPositionWithZ(Input.mousePosition , Camera.main);

}
public static  Vector3 GetMouseWorldPositionWithZ( Camera worldCamera ) {
    return GetMouseWorldPositionWithZ(Input.mousePosition , worldCamera ) ;
}
public static Vector3 GetMouseWorldPositionWithZ (Vector3 screenPosition , Camera worldCamera ) {
    Vector3 worldPosition = worldCamera.ScreenToWorldPoint ( screenPosition ) ;
    return worldPosition ;
}
}
