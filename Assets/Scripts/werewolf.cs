using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class werewolf : MonoBehaviour
{
    public int HP = 100;
    public Animator animator;
    public KillCount killCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damageAmount){
        HP -= damageAmount;
        if(HP <= 0){
            //play death animation
            animator.SetTrigger("die");
            GetComponent<Collider>().enabled = false;
            killCount.updateWolfLeft();
            return;
        }
        else {
            //play get hit animation
            animator.SetTrigger("damage");

        }
    }
    
}



