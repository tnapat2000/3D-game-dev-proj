using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public int selectedWeapon = 0;
    // Start is called before the first frame update
    public PlayerMovement playerMovement;

    bool isAlive;
    void Start()
    {   
        SelectWeapon();
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {   
        isAlive = playerMovement.isAlive;
        if (!isAlive) {
            foreach(Transform weapon in transform){
                weapon.gameObject.SetActive(false);    
            }
            return;
        }
        WeaponWheel();
    }

    void SelectWeapon(){
        int i = 0;
        foreach(Transform weapon in transform){
            if ( i == selectedWeapon){
                weapon.gameObject.SetActive(true);
            }else{
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }

    void WeaponWheel(){
        int previousSelectedWeapon = selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") < 0f) {
            if (selectedWeapon >= transform.childCount -1){
                selectedWeapon = 0;                
            }else{
                selectedWeapon++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) {
            if (selectedWeapon <= 0){
                selectedWeapon = transform.childCount -1;                
            }else{
                selectedWeapon--;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)){
            selectedWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2){
            selectedWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3){
            selectedWeapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4){
            selectedWeapon = 3;
        }

        if ( previousSelectedWeapon != selectedWeapon){
            SelectWeapon();
        }
    }
}
