using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumboJoeManager : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;


   [Header("Player Target")]
   public Transform player;

   [Header("Ranges")]
   public float attackRange;

   public float speed = 2;
   public bool isFlipped;

   [Header("Damages")]
   public Transform attackPos;
   public int energyDamages; //for player
   public float attackRadius;
   public LayerMask attackmask;

   public int attackDamage = 4;

   public Transform rightTarget, leftTarget;

   [Header("Projectiles")]
   public List<GameObject> moneyProjectile;
   public Transform shootingPos;

   public float fireRate;
   private float nextTimeShoot;

   private JumboeJoeHealth health;


   public enum BossStates{
      entry,
      punch,
      follow,
      backoff,
      specialattack, 
      dead
   }



    public BossStates currentstate = BossStates.entry;


    private void Start() {


     anim = GetComponent<Animator>();
     rb = GetComponent<Rigidbody2D>();
     health = GetComponent<JumboeJoeHealth>();

   }

   public void LookAtPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (transform.position.x > player.position.x && isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		else if (transform.position.x < player.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
		}
	}

   private void Update() {

    LookAtPlayer();

       if(currentstate == BossStates.entry){
        StartCoroutine(BossEntry(anim.GetCurrentAnimatorStateInfo(0).length));
        currentstate = BossStates.punch;
       }

       if(currentstate == BossStates.punch){ // calculate purcentage

          if(Vector2.Distance(player.position, transform.position) <= attackRange){
              anim.SetBool("closeenough", true);// the attack function will be applied in the animator (add event)
          }
          else{
            anim.SetBool("closeenough", false); // the follow function will be applied in the animator (add event)
          }
       }

       //see trigger enter for backofff conditions

       if(currentstate == BossStates.follow){
        followstate();
       }

       if(currentstate == BossStates.backoff){
         backingoff();
       }

       if(currentstate == BossStates.specialattack){
        anim.SetBool("backingoff_done", true);
          Specialattackbackoff();
       }

       if(currentstate == BossStates.dead){
        anim.SetTrigger("death");
       }
   }

       public  IEnumerator BossEntry(float _waitTime){
        //update opening ui
        Debug.Log("Boss Battle Starts!");
        
        yield return new WaitForSeconds(_waitTime); // waitime is supposed to equal animation wait time
        
    }

    public void PunchAttack(){
       Collider2D[] collider2D = Physics2D.OverlapCircleAll(attackPos.position, attackRadius, attackmask);

       foreach ( Collider2D battler in collider2D)
       {
         battler.GetComponent<CharacterController>().TakeEnergy(energyDamages);
       }
        health.nodamage = false; 
    }

     public void follow(int _speed){
        Vector2 target = new Vector2(player.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(rb.position, target, _speed * Time.deltaTime);
        health.nodamage = false; 
    }

    public void followstate(){
        anim.SetBool("punch_attack_done", true);
        Vector2 target = new Vector2(player.position.x - 1f, transform.position.y);
        transform.position = Vector2.MoveTowards(rb.position, target, speed * Time.deltaTime);
        GetComponent<SpriteRenderer>().color = Color.red;
        health.nodamage = false; 
    }

    public void backingoff(){
        anim.SetBool("followdone", true);
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        health.nodamage = true;   
    }

    public void Specialattackbackoff(){
        transform.position = Vector2.MoveTowards(transform.position, rightTarget.position, speed * Time.deltaTime);
health.nodamage = true;
 
    
    }
    

     void specialattack(){

         int index = UnityEngine.Random.Range(0 , moneyProjectile.Count);

         if(Time.time > nextTimeShoot){
            Instantiate(moneyProjectile[index], shootingPos.position, Quaternion.identity);
            nextTimeShoot = Time.time  + 1f / fireRate;
         }

    }


    private void OnDrawGizmosSelected() {

        if(attackPos == null){
            return;
        }
        Gizmos.DrawWireSphere(attackPos.position, attackRadius);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(currentstate ==BossStates.backoff){
            if(other.gameObject == leftTarget.GetComponent<BoxCollider2D>() || rightTarget.GetComponent<BoxCollider2D>() ){
              //set following anim and and creating script for anim behavior
              anim.SetBool("inBorders", true);
              backingoff();
            }
            else{
                //set backoff anim and and creating script for anim behavior
                 anim.SetBool("inBorders", false);
            }
        }

         if(currentstate ==BossStates.specialattack){
            if(other.gameObject == leftTarget.GetComponent<BoxCollider2D>() || rightTarget.GetComponent<BoxCollider2D>() ){
              //set following anim and and creating script for anim behavior
              anim.SetBool("isTouchingRightBound", true);
            }
            else{
                //set backoff anim and and creating script for anim behavior
                 anim.SetBool("isTouchingRightBound", true);
            }
        }
    }





}
