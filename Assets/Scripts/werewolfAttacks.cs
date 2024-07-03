using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class werewolfAttacks : MonoBehaviour
{
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
    public void Attack(int damageAmount){
        PlayerMovement.currentHealth -= damageAmount;
    }
}
