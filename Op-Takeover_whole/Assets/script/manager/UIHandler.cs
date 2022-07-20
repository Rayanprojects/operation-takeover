using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHandler : MonoBehaviour
{
    public TextMeshProUGUI num_energy;
    public TextMeshProUGUI specialattack_left;
    public TextMeshProUGUI slow_mo_info;
    private CharacterController player;
    bool slow_motion_on;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<CharacterController>().GetComponent<CharacterController>();
        slow_motion_on = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUi();
        if(player.jumped){
            slow_motion_on = true;
        }
        else if(player.jumped == false){
            slow_motion_on = false;
        }
        
    }

    void UpdateUi(){
        num_energy.text = "energy:" + player.energy.ToString();
        specialattack_left.text = "number of special attacks:" + player.specialattacknum.ToString();
    
            slow_mo_info.text = $"slomo= {slow_motion_on}";

    }
}
