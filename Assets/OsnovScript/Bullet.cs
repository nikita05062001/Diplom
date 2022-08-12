using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 15.0f;
    private SpriteRenderer sprite;
    private Vector3 direction;
    public Vector3 Direction { set { direction = value; } }
    private Rigidbody2D rb;
    public int naprav =1;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Destroy(gameObject, 1.4f);
    }

    private void Update()
    {
        if (naprav ==1)
        rb.velocity = new Vector2(1 * speed, rb.velocity.y);
        if (naprav ==-1)
        rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
        // transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
