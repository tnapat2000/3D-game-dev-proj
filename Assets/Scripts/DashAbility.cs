using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashAbility : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Image image;
    float cooldown;
    // Start is called before the first frame update
    bool canDash;
    void Start()
    {
        cooldown = playerMovement.cooldown;
        image.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        if (!canDash){
            image.fillAmount -= 1 / cooldown * Time.deltaTime;
            if(image.fillAmount <= 0){
                image.fillAmount = 0;
                canDash = playerMovement.canDash;   
            }
        }else{
            image.fillAmount = 1;
            canDash = playerMovement.canDash;
        }

    }
}
