using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour {

    public Transform weaponTransform;  
    public Rigidbody projectile;        
    public float shootingForce = 1000.0f;
    public GameObject dummyArrow;

    private WaitForSeconds cooldownTime = new WaitForSeconds(0.7f);
    private bool cooldownExpired = true; //okay to shoot
    private bool noArrow = true;


    // Update is called once per frame
    void Update()
    {
        if (noArrow && cooldownExpired)
        {
            dummyArrow.SetActive(true);
            noArrow = false;
        }
        if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) && cooldownExpired)
        {
            //Create a projectile instance and add a force to it
            Rigidbody shot = Instantiate(projectile, dummyArrow.transform.position, dummyArrow.transform.rotation) as Rigidbody;   
            shot.AddForce(weaponTransform.forward * shootingForce);

            //Make initial arrow disappear
            dummyArrow.SetActive(false);
            noArrow = true;
            cooldownExpired = false;
            StartCoroutine(WeaponEffect());
        }
    }

    private void RaycastWeapon()
    {
        RaycastHit hit;
        if (Physics.Raycast(weaponTransform.position, weaponTransform.forward, out hit))
        {
            if (hit.collider.gameObject.CompareTag("shootable"))
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }

    private IEnumerator WeaponEffect()
    {
        //Wait for # seconds before making dummy arrow appear
        yield return cooldownTime;
        cooldownExpired = true;
    }
}

