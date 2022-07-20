using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUi : MonoBehaviour
{
     public Slider boss_Slider, boss_energy_Slider;
     private JumboeJoeHealth jjHealth;

     private void Start() {
        jjHealth.GetComponent<JumboeJoeHealth>();
     }

     void UpdateValue(){
        boss_Slider.value = jjHealth.health;
        boss_Slider.value = jjHealth.energy;
     }

}
