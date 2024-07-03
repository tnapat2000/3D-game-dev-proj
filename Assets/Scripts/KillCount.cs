using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class KillCount : MonoBehaviour
{
    // public GameSess gameSess;
    public TextMeshProUGUI slain;
    // Start is called before the first frame update
    public int werewolfLeft;
    void Start()
    {
        werewolfLeft = FindObjectsOfType<werewolf>().Length;
        slain.text = werewolfLeft.ToString();
    }

    // Update is called once per frame
    void Update()
    {        
        // werewolfLeft = FindObjectsOfType<werewolf>().Length;
        // slain.text = werewolfLeft.ToString();        
    }

    public void updateWolfLeft(){
        werewolfLeft -= 1;
        slain.text = werewolfLeft.ToString();
    }
}
