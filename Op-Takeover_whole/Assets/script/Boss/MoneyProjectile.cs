using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyProjectile : MonoBehaviour
{
     public float speed;
    public int bulletDamage;


    // Update is called once per frame
    void Update()
    {
       transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
         if(other.gameObject.tag == "player"){
            other.gameObject.GetComponent<CharacterController>().TakeEnergy(bulletDamage);
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            Destroy(gameObject);
            //particle effect
        }
    }


}
