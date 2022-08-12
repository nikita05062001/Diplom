using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    private float speed = 15.0f;
    private SpriteRenderer sprite;
    private Vector3 direction;
    private Character gameobject;
    public Vector3 Direction { set { direction = value; } }

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        gameobject = GetComponent<Character>();
    }

    private void Start()
    {
        Destroy(gameObject, 6f);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
