using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolenemy : enemy
{
    private enemyhealth enhealth;
        public float followRange;
    public bool canFollow;
    public Vector3 distance_from_player;
    public float speed;
    public float speedmodify;

     private Transform player;

  
    // Start is called before the first frame update
    void Start()
    {
       enhealth = GetComponent<enemyhealth>();
       enhealth.SetHealth();
       player = FindObjectOfType<CharacterController>().transform;
    }

    // Update is called once per frame

     private void LateUpdate() {

        Vector2 distance = player.position - transform.position;
       


        if(distance.magnitude > followRange){
            canFollow = false;
        }
        else if(distance.magnitude < followRange){
            currenstate = EnemyStates.follow;
            canFollow = true;
        }

        if(!canFollow){
            currenstate = EnemyStates.idle;
            speed = 0;
        }

        if(currenstate == EnemyStates.follow){
           MoveEnemy();
        }

        if( enhealth.health <= 0){
           currenstate = EnemyStates.dead;
           Death();
        }
     } 

       void MoveEnemy(){
  
        speed = speedmodify; /*hardcoded sry*/;
        transform.position = Vector2.MoveTowards(transform.position, player.position , speed * Time.deltaTime);  
    }
}
