using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class  BossKod: MonoBehaviour
{
    public int lungeForce = 20;
    public float speed = 9f;
    private SpriteRenderer sprite;
    public int naprav = 1;
    public GameObject gameobject;
    public bool stoy = false;
    public bool verh = false;
    public bool НачатьСПрава = false;
    public int Vniz = -1;
    private Vector3 P;
    public int health;
    public float cooldowndamage = 0f;
    public float cooldowndamagebullet = 0f;
    public Text HP;
    public GameObject Diplom;

    private Rigidbody2D rb;
    private float jumpCooldown = 2f;

    public void TakeDamage(int damage)
    {
        if (cooldowndamage >= 0.23f)
        {
            health -= damage;
            cooldowndamage = 0;
            speed += 0.2f;
            naprav = -naprav;
        }
    }
    private void Update()
    {
        cooldowndamagebullet += Time.deltaTime;
        cooldowndamage += Time.deltaTime;
        if (health <= 0)
        {
            Diplom.SetActive(false);
            Destroy(gameObject);
        }
        HP.text =  health.ToString();
        if (jumpCooldown >= 4f)
        {
            rb.velocity = Vector2.up * 15;
            jumpCooldown = 0;
        }
        jumpCooldown += Time.deltaTime;
    }
    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
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
        if (other.gameObject.tag == "Lift") Vniz = Vniz * (-1);
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
            if (cooldowndamagebullet >= 0.23f)
            {
                health -= 1;
                speed += 0.2f;
                cooldowndamagebullet = 0;
            }
        }
    }
    private void Run()
    {
        Vector3 direction = transform.right * naprav;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        sprite.flipX = direction.x < 0.0f;
    }
}