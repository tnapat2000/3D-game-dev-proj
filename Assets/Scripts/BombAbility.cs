using UnityEngine;
using UnityEngine.UI;

public class BombAbility : MonoBehaviour
{
    public GrenadeThrow grenadeThrow;
    public Image image;
    float cooldown;
    // Start is called before the first frame update
    bool canFire;
    // Start is called before the first frame update
    void Start()
    {
        cooldown = grenadeThrow.cooldownTime;
        image.fillAmount = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (!canFire){
            image.fillAmount -= 1 / cooldown * Time.deltaTime;
            if(image.fillAmount <= 0){
                image.fillAmount = 0;
                canFire = grenadeThrow.canFire;   
            }
        }else{
            image.fillAmount = 1;
            canFire = grenadeThrow.canFire;
        }
    }
}
