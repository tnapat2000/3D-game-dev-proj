using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Gun : MonoBehaviour
{
    [SerializeField] int damage = 10;
    // [SerializeField] float range = 100f;
    // [SerializeField] float impactForce = 100f;
    [SerializeField] float fireRate = 15f;
    private bool isReloading = false;
    public int maxAmmo = 10;
    int currentAmmo, ammoShot;
    public int bulletPerTap = 1;
    public float reloadTime = 1f;
    private float nextTimeToFire = 0f;
    public Animator gunAnimator;
    public ParticleSystem muzzleFlash;
    public GameObject bullet;
    public Vector3 recoil;    
    private Vector3 originalRotation;
    public float spreadAngle;
    public float speed;
    public WeaponUI weaponUI;
    // public GameObject bulletHole;
    void Start(){
        currentAmmo = maxAmmo;
        originalRotation = transform.localEulerAngles;
    }

    void Update()
    {   
        if (isReloading) {
            return;
        }
        if (currentAmmo <= 0 || (currentAmmo < maxAmmo && Input.GetKeyDown("r"))) {
            StartCoroutine(Reload());
            return;
        }
        if(Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire){
            nextTimeToFire = Time.time + 1f /fireRate;
            ammoShot = bulletPerTap;
            Shoot();
            transform.localEulerAngles += recoil;

        } else if (Input.GetButtonUp("Fire1")){
            transform.localEulerAngles = originalRotation;
        }   
        UpdateWeaponInfo();
     }

    void OnEnable () {
        isReloading = false;
        gunAnimator.SetBool("isReloading", false);
        transform.localEulerAngles = originalRotation;
    }

    void Shoot(){
        currentAmmo -= ammoShot;
        // Debug.Log(currentAmmo);
        muzzleFlash.Play();
        // RaycastHit hit;
        for (int i = 0; i < bulletPerTap; i++){
            GameObject go = Instantiate(bullet, transform.position, transform.rotation);
            // Debug.Log(transform.position);
            Bullet spawned_bullet = FindObjectOfType<Bullet>();
            spawned_bullet.setDamage(damage);
            spawned_bullet.setSpeed(speed);
            if (gameObject.name == "Shotgun"){
                // Debug.Log("Shotgun shoot " + i.ToString());
                go.transform.rotation = Quaternion.RotateTowards(go.transform.rotation, Random.rotation, spreadAngle);
                // go.GetComponent<Rigidbody>().AddForce(go.transform.right* 5);
            }
            go.transform.Rotate(new Vector3(90,0,0));
            Destroy(go, 3f);
        }
    }

    IEnumerator Reload() {
        isReloading = true;
        // Debug.Log("reloading...");
        gunAnimator.SetBool("isReloading", true);

        yield return new WaitForSeconds(reloadTime - 0.25f);
        gunAnimator.SetBool("isReloading", false);

        yield return new WaitForSeconds(0.25f);
        // Debug.Log("reloading... done");
        currentAmmo = maxAmmo;
        isReloading = false;
        transform.localEulerAngles = originalRotation;
    }

    void UpdateWeaponInfo(){
        weaponUI.UpdateText(gameObject.name, maxAmmo, currentAmmo);
    }
}
