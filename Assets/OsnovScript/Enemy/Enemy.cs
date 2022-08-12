using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int lungeForce = 20;
    public float speed = 9f;
    private SpriteRenderer sprite;
    private int naprav = 1;
    public GameObject gameobject;
    public bool stoy = false;
    public bool verh = false;
    public bool НачатьСПрава = false;
    public int Vniz = -1;
    private Vector3 P;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    private void Start()
    {
        if (НачатьСПрава == true) naprav = naprav * -1;
    }

    private void FixedUpdate()
    {
        if (stoy == false)
        {
            Vector3 direction = transform.right * naprav;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
            sprite.flipX = direction.x < 0.0f;
        }
        if (verh == true)
        {
            //получим текущую позицию лифта
            P = this.transform.position;
            //задаем движение относительно оси Y
            if (Vniz == -1)
            P.y = P.y + speed * naprav * Time.deltaTime;
            if (Vniz == 1)
                P.y = P.y + (-1 * speed * naprav * Time.deltaTime);
            //меняем координаты лифта на новые 
            transform.position = P;
            //if (P.y > 17.5f) naprav = naprav * (-1);
           // if (P.y < -5f) naprav = naprav * (-1);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Lift") Vniz = Vniz *(-1);
        if (other.gameObject.tag == "GameController")
        {
            naprav = naprav * (-1);
        }
        if (other.gameObject.tag == "Player")
        {
            var obj = gameobject.GetComponent<Character>();
            obj.ReciveDamage();
            obj.JumpDamageCoolDOwn = 0f;
            if (sprite.flipX == false)
               obj.rigidbody.velocity = Vector2.right * lungeForce;
            else
               obj.rigidbody.velocity = Vector2.left * lungeForce;
              
            naprav = naprav * (-1);
        }
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
    private void Run()
    {
        Vector3 direction = transform.right * naprav;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        sprite.flipX = direction.x < 0.0f;
    }
}
// obj.rigidbody.AddForce(Vector2.left * lungeForce, ForceMode2D.Impulse);
// obj.rigidbody.AddForce(Vector2.right * lungeForce);
// Destroy(gameObject);
// obj.rigidbody.AddForce(Vector2.right * lungeForce, ForceMode2D.Impulse);
//obj.rigidbody.AddForce(Vector2.right * lungeForce);