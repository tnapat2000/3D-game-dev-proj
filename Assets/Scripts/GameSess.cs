using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSess : MonoBehaviour
{
    // int werewolfKilled = 0;
    public int werewolfLeft;
    // Start is called before the first frame update
    void Awake()
    {  
        int numGameSess = FindObjectsOfType<GameSess>().Length;
        if(numGameSess > 3) {
            Destroy(gameObject);
        }else{
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start(){
        werewolfLeft = FindObjectsOfType<werewolf>().Length;
        // Debug.Log(werewolfLeft);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateKillCount(){
        werewolfLeft -= 1 ;
    }

}
