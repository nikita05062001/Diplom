using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{


   public GameObject gameobject;



    void OnTriggerEnter2D(Collider2D other)
    {
       
            if (other.gameObject.tag == "Player")
        {
            var obj = gameobject.GetComponent<Character>();
            var objjump = gameobject.GetComponent<Rigidbody2D>();
            obj.ReciveDamage();
            Debug.Log(obj.Lives);
            Destroy(gameObject);
         //   objjump.AddForce(transform.up * 5, ForceMode2D.Impulse);
        }
    }
}
