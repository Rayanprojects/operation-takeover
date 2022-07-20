using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthEnemy : MonoBehaviour
{
     public Slider healthBar;
    

    public void SetHealth(float health, float maxHealth){
       healthBar.value = health;
        healthBar.maxValue = maxHealth;
    }
}
