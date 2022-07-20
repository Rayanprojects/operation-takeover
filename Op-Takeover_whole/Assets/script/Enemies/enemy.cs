using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

     public int damage;



    public enum EnemyStates{
        idle,
        follow,
        dead
    }
    public EnemyStates currenstate;

    // Start is called before the first frame update
    void Start()
    {
        currenstate = EnemyStates.idle;
    }

    public void Death(){
        if(currenstate == EnemyStates.dead){
           Destroy(gameObject);
        }
    }


    



}

