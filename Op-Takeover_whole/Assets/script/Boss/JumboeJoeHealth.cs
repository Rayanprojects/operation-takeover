using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumboeJoeHealth: MonoBehaviour
{
    public Slider healthBar;

    private JumboJoeManager jj;
    public bool nodamage;

    [Header("health")]
   public int health;
  public int maxhealth = 500;
   public int energy;
   public int maxenergy = 500;

   private Animator anim;
    
     
     private void Start() {
        anim = GetComponent<Animator>();
        jj = GetComponent<JumboJoeManager>();
        health = maxhealth;
        energy = maxenergy;

        sliderSetMaxHealh(maxhealth);
     }

     private void Update() {
          SetHealth(health);
        if(health <=500 && health >= 375){
            jj.currentstate = JumboJoeManager.BossStates.punch;
        }
        if(health <= 300 && health >= 250){
            jj.currentstate = JumboJoeManager.BossStates.follow;
        }

        if(health <= 225  && health >=  125){
            jj.currentstate = JumboJoeManager.BossStates.backoff;
        }

        if(health <= 125){
            jj.currentstate = JumboJoeManager.BossStates.specialattack;
        }

        if(health <= 0){
           Die();
        }
     }
    public void SetHealth(float health, float maxHealth){
       healthBar.value = health;
        healthBar.maxValue = maxHealth;
    }

    public void TakeHealthAway(int _healthTakeAway){
        if(!nodamage){
          health -= _healthTakeAway;
        }

    } 

    public void TakeEnergyAway(int _energyDamages){
       energy -= _energyDamages;
    }

    public void Die(){
        //any sort of ui
        //particale system
        //dialogue

        Debug.Log("you won");
        Destroy(gameObject);
        jj.currentstate = JumboJoeManager.BossStates.dead;
    }
    

    //take damge function calucaltes each and every states according to the health (check miro)

    public void sliderSetMaxHealh(int health){
        healthBar.maxValue = health;
        healthBar.value = health;
    }

    public void SetHealth(int health){
         healthBar.value = health;
    }

}
