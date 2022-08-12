using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBook : MonoBehaviour
{
    private BulletEnemy bullet;
    public bool СтрелятьПоГоризонтале = false;
    public bool СтрелятьПоВертикале = false;
    public int СтрелятьВЛево = -1;
    public int СтрелятьВНиз = -1;
    public float CoolDownShot = 0f;
    public float CoolDown = 4;
    void Start()
    {
        bullet = Resources.Load<BulletEnemy>("BulletEnemy");
    }

    // Update is called once per frame
    void Update()
    {
        CoolDownShot += Time.deltaTime;
        if (CoolDownShot > CoolDown)
        {
            Vector3 position = transform.position; position.y += 0.5f;
            BulletEnemy NewBullet = Instantiate(bullet, position, bullet.transform.rotation) as BulletEnemy;
            if (СтрелятьПоГоризонтале == true) 
            NewBullet.Direction = NewBullet.transform.right * СтрелятьВЛево;
            if (СтрелятьПоВертикале == true)
            NewBullet.Direction = NewBullet.transform.up * СтрелятьВНиз;
            CoolDownShot = 0f;
        }
    }
}
