using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 5f;
    public int bulletDamage = 20;
    float speed;
    Rigidbody rgbd;
    Gun gun;
    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody>();
        gun = FindObjectOfType<Gun>();
        speed = gun.transform.localScale.x * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // rgbd.velocity = new Vector3(speed, 0f);
        rgbd.AddForce(gun.transform.forward * speed, ForceMode.VelocityChange);
    }

    void OnCollisionEnter(Collision other){
        if(other != null && other.gameObject.tag == "Shootable"){
            Target enemygo = other.gameObject.GetComponent<Target>();
            enemygo.TakeDamage(bulletDamage);
        }
        if(other.gameObject.name != "Bullet(Clone)"){
            Destroy(gameObject);
        }
    }

    public void setDamage(int damage){
        this.bulletDamage = damage;
    }

    public void setSpeed(float speed){
        this.speed = speed;
    }
    private void OnTriggerEnter(Collider other){
        if (other.tag == "Werewolf" ){
            transform.parent = other.transform;
            other.GetComponent<werewolf>().TakeDamage(bulletDamage);
        }
    }

    
}
