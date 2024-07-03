using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float delay = 3f;
    public float blastRadius = 5f;
    public float force = 700f;
    public int blastDamage = 50;

    public GameObject explosionEffect;
    float countdown;
    bool hasExploded = false;
    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded){
            Explode();
            hasExploded = true;
        }
    }

    void Explode(){

        GameObject go = Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(go, 2f);

        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);

        foreach (Collider nearbyObj in colliders) {
            if (nearbyObj.tag == "Player") {
                PlayerMovement player =  nearbyObj.GetComponent<PlayerMovement>();
                player.TakeDamage(blastDamage);
                Debug.Log(blastDamage);
            }
            if (nearbyObj.tag == "Shootable"){
                // Debug.Log(nearbyObj.name);
                Target target = nearbyObj.GetComponent<Target>();
                target.TakeDamage(blastDamage);
            }
            if (nearbyObj.tag == "Werewolf"){
                transform.parent = nearbyObj.transform;
                nearbyObj.GetComponent<werewolf>().TakeDamage(blastDamage);
            }

            Rigidbody rb =  nearbyObj.GetComponent<Rigidbody>();
            if (rb != null) {
                rb.AddExplosionForce(force, transform.position, blastRadius);
            }
        }

        Destroy(gameObject);
    }
}
