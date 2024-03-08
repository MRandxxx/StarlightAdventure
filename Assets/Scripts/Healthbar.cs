using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{

    //Set health to full.
    public Image healthbar;
   public void SetHealth(int health)
    {
        healthbar.fillAmount = 1f;
    }


    //Caluculate health and update healthbar.
    public void SetHealth(int health, int fullHealth)
    {
        healthbar.fillAmount = (float)health / fullHealth;
    }
}
