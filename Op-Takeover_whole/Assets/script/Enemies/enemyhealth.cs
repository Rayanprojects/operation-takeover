using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhealth : MonoBehaviour
{
     public HealthEnemy healthManagerEnemy;
    public float health;
    public int maxHealth = 5;

    private void Start() {
        SetHealth();
    }

     public void SetHealth(){
        health = maxHealth;
    }


    public void TakeDamage(float damage){
        healthManagerEnemy.SetHealth(health, maxHealth);
         health -= damage;
    }


}
