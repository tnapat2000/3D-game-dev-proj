using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public Animator animator;
    // public GameSess gameSess;
    public KillCount killCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(killCount.werewolfLeft <= 0){
            Debug.Log(killCount.werewolfLeft);
            animator.SetTrigger("CanOpen");
        }else{
            animator.ResetTrigger("CanOpen");
        }
    }
}
