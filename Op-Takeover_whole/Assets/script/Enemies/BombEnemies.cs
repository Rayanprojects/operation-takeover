using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemies : enemy
{
     private enemyhealth enhealth;
     public float bombing_Radius;
     public Transform bombPos;
     public LayerMask playerMask;
      private Transform player;

      public int bombingRange;

    // Start is called before the first frame update
    void Start()
    {
       enhealth = GetComponent<enemyhealth>();
       enhealth.SetHealth();
       player = FindObjectOfType<CharacterController>().transform;
       GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }

    // Update is called once per frame

     private void LateUpdate() {
        startbombing();


        if( enhealth.health <= 0){
           currenstate = EnemyStates.dead;
           Death();
        }
     } 

     void startbombing(){
        Vector2 distance = player.position - transform.position;
        Debug.Log(distance.magnitude);

        if(distance.magnitude < bombingRange){
            Bomb();
        }
     }

       void Bomb(){
          Debug.Log("Bombed");
          //instantiate particle effect

             Collider2D[] collider2D = Physics2D.OverlapCircleAll(bombPos.position, bombing_Radius, playerMask);

       foreach ( Collider2D battler in collider2D)
       {
         battler.GetComponent<CharacterController>().TakeEnergy(damage);
       }
       GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
      }

      private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(bombPos.position,bombing_Radius);
      }
}
