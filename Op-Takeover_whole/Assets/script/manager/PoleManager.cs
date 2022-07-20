using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleManager : MonoBehaviour
{
    private PlatformEffector2D effector2D;
    public float waititme;

     public bool _flooractive;
     bool isactive;

     int floorLenght;

    private void Start() {
         effector2D = GetComponentInChildren<PlatformEffector2D>();

    }

    private void Update() {
        if(Input.GetKeyUp(KeyCode.S)){
            waititme = 0.5f;
        }
        if(Input.GetKeyDown(KeyCode.S)){
            effector2D.rotationalOffset = 180f;
           if(waititme <= 0){
            waititme = 0.5f;
           }else{
              waititme -= Time.deltaTime;
           }
        }

        if(Input.GetKey(KeyCode.Space)){
            effector2D.rotationalOffset = 0f;
        }



    }

    }



