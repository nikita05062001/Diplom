using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour
{
    public int Vniz = 1;
    private Vector3 P;
    public int speed = 3;
    public int naprav = -1;
    void OnCollisionEnter2D(Collision2D coll)
    {
       coll.transform.parent = transform;
    }

    void OnCollisionExit2D(Collision2D coll)
    {
       coll.transform.parent = null;
    }
    private void FixedUpdate()
    {
        if (Vniz == 1 || Vniz == -1)
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
        }
        if (Vniz == 0)
        {
            Vector3 direction = transform.right * naprav;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Lift") Vniz = Vniz * (-1);
        if (other.gameObject.tag == "GameController") naprav = naprav * (-1);  
    }
}