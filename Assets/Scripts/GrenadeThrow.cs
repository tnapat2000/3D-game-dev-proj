using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrow : MonoBehaviour
{
    public float throwForce = 40f;
    public float cooldownTime = 15;
    public float nextFireTime = 0;
    public GameObject grenade;
    public bool canFire;
    // Start is called before the first frame update
    void Start()
    {
        canFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFireTime){
            canFire = true;
        }
        if (Input.GetKeyDown("g") && canFire) {
            ThrowGrenade();
            nextFireTime = Time.time + cooldownTime;
            canFire = false;
        }
    }

    void ThrowGrenade() {
        GameObject gred = Instantiate(grenade, transform.position, transform.rotation);
        Rigidbody rb = gred.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }
}
