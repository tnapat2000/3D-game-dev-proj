using UnityEngine;
using TMPro;

public class WeaponUI : MonoBehaviour
{
    public TextMeshProUGUI maxAmmoText;
    public TextMeshProUGUI currentAmmoText;
    public TextMeshProUGUI gunnameText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateText(string gunname,  int maxAmmo, int currentAmmo){
        maxAmmoText.text = maxAmmo.ToString();
        currentAmmoText.text = currentAmmo.ToString();
        gunnameText.text = gunname.ToString();
    }

}
