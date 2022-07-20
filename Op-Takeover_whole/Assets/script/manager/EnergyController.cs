using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyController : MonoBehaviour
{
    public CharacterController character;
    public int maxEnergy = 100;
    public bool cannotGetEnergy;
    // Start is called before the first frame update
    void Start()
    {
        character.energy = maxEnergy;
        

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.E) && !cannotGetEnergy && character.energy < 30){
            character.energy += 50;
            cannotGetEnergy = true;
        }
    }
}
