using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private CharacterController player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<CharacterController>().GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.energy == 0){
            RestartLevel();
        }
    }


    void RestartLevel(){
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
