using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerprojectileleft : MonoBehaviour
{
    public float speed;
    public int bulletDamage;


     private void Start() {
        
     }
    // Update is called once per frame
    void Update()
    {
       transform.Translate(Vector2.left * speed * Time.deltaTime); // change in dir
    }

    private void OnCollisionEnter2D(Collision2D other) {

        if(other.gameObject.tag == "boss"){
            other.gameObject.GetComponent<JumboeJoeHealth>().TakeHealthAway(bulletDamage);
            Destroy(gameObject);
            //particle effect
        }

          if(other.gameObject.tag == "Enemie"){
            Destroy(gameObject);
            other.gameObject.GetComponent<enemyhealth>().TakeDamage(.5f);

            
        }
    }
}
