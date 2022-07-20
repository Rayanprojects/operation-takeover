using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterController : MonoBehaviour
{
   /* public UIHandler ui;
    private GameManager game;*/
    public float speed;
    public float jumpHeight;
    [HideInInspector] public Animator anim;




    public  int energy = 250;
    public bool canBoost;

    public bool attackboost = false;
    public bool jumpboost = false;
    public bool specialattackboost = false;
    /*private bossController boss;*/

    CircleCollider2D circleCollider2D;

    Rigidbody2D rb;
    float Horizontal;


    public bool hasAttacked;
    public bool isGrounded;
    public bool canGetInput = true;

    public Transform groundCheck;
    public LayerMask ground;

    public bool jumped;
    

    SpriteRenderer sr;
    public Transform attackPos;
    public Transform leftattackPos;

    public int specialattacknum;

    float timepressedwait;

    [Header("Projectile")]

    public GameObject bullet;


 


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        hasAttacked = false;
        jumped =false;
        Time.timeScale = 1;
       
       /* circleCollider2D.radius = transform.localScale.x - 0.35f; */
        anim = GetComponent<Animator>();
          /*game = GameObject.Find("GameManager").GetComponent<GameManager>();*/

    }

    // Update is called once per frame
    void LateUpdate()
    {
        GetInput();
        if(energy == 0)
        {
           Debug.Log("your dead has come");
        }


        /*if(updated == false){
            enemiesKillNum--;
            updated = true;
        }
        updated  = false;*/

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 10f, ground);
        

 
    
    }



    void GetInput(){
 
         Horizontal = Input.GetAxis("Horizontal");
         anim.SetBool("isMoving", false);


        if(Input.GetKey(KeyCode.A)){
            sr.flipX = true;
            transform.Translate(new Vector2(-speed , 0) * -Horizontal * Time.deltaTime);
            anim.SetBool("isMoving", true);
        }


        if(Input.GetKey(KeyCode.D)){
            sr.flipX = false;
            transform.Translate(new Vector2(speed , 0) * Horizontal * Time.deltaTime);
            anim.SetBool("isMoving", true);
        }



        if(Input.GetKey(KeyCode.Space) && isGrounded){
            Time.timeScale = 0.1f;
             Time.fixedDeltaTime = 0.02f * Time.timeScale;
            if(jumpboost == false){
              Jump();
              jumpboost = true;
            }

            jumpboost = true;
        } 
        else if(jumpboost){
            energy -= 1;
             Time.timeScale = 1f;
              anim.SetBool("isJumping", false);
            jumpboost = false;
            jumped = false;
        }
        
       
         if(Input.GetKey(KeyCode.F)){ /*was before h*/

         
            if(attackboost == false){
                anim.SetBool("isAttacking", true);
              StartCoroutine(Hit(anim.GetCurrentAnimatorStateInfo(0).length ));
              attackboost = true;
            }

            attackboost = true;

        }
        else if(attackboost){
            energy -= 2;
            anim.SetBool("isAttacking", false);
            attackboost = false;
        }
        
        if(Input.GetKey(KeyCode.X)){
            StartCoroutine(SpecialAttackInput()) ;
        }
          

        

    }

    IEnumerator SpecialAttackInput(float delay = 0){
          yield return new WaitForSeconds(delay);
       if(!sr.flipX){
        transform.position =  Vector2.MoveTowards(transform.position, attackPos.position, speed);
        hasAttacked = true;
       }

       else if(sr.flipX){
           transform.position =  Vector2.MoveTowards(transform.position, leftattackPos.position, speed);
         hasAttacked = true;
       } 


    }
    
   

    void Jump(){
        rb.velocity = Vector2.up * jumpHeight;

        anim.SetBool("isJumping", true);
        jumped = true;
    }


    
   IEnumerator Hit(float delay = 0){
      yield return new WaitForSeconds(delay);

         Instantiate(bullet , attackPos.position, transform.rotation);


    //particle effect

    }




    public int TakeEnergy(int _energyAmount){
        return energy -= _energyAmount;
    }

    void SpecialAttack(){
        
    specialattacknum--;
    if(!sr.flipX){
        transform.position =  Vector2.MoveTowards(transform.position, attackPos.position + new Vector3(2, 0, 0), speed + 2);
       }
       else if(sr.flipX){
           transform.position =  Vector2.MoveTowards(transform.position, leftattackPos.position  + new Vector3(-2, 0, 0), speed + 2);
       }
      
    }
       

     void OnCollisionEnter2D(Collision2D col) {


 
        //if(col.gameObject.CompareTag("Enemie") && hasAttacked == true){
            //var enemy = GameObject.FindGameObjectWithTag("Enemie").GetComponent<enemy>();
            //enemy.TakeDamage(0.5f);
            ///hasAttacked = true;
       // }

        //*if(col.gameObject.GetComponent<enemy>() && hasAttacked ){
            //var enemy = GameObject.FindGameObjectWithTag("Enemie").GetComponent<enemy>();
            //enemy.TakeDamage(0.5f);

       // }

    }




    private void OnTriggerEnter2D(Collider2D col) {
     
    }

    private void OnTriggerExit2D(Collider2D other) {

    }







}
