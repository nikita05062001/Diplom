using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Character : Unit
{
    public float JumpDamageCoolDOwn = 0.6f;
    private float curr_time = 0f;

    public AudioSource Myfx;
    public AudioClip DeadSound;
    public AudioClip JumpSound;
    public AudioClip HitsSound;
    public AudioClip DamageSound;

    public bool isLevel1= false;
    public bool isLevel2 = false;
    public bool isLevel3 = false;
    public bool isLevel4 = false;
    public bool isLevel5 = false;
    private int lives = 5;

    public int Lives
    {
        get { return lives; }
        set
        {
            if (value < 5) lives = value;
            livesBar.Refresh();
        }
    }
    private LivesBar livesBar;

    [SerializeField]
    private float speed = 6.0f;
    public float fastspeed = 10.0f;
    private float realspeed;
    private bool speedlock;
    private Vector2 moveVector;
    private bool faceRight = true;
    [SerializeField]
    private float jumpforce = 15.0f;

    private Bullet bullet;

    public bool isGrounded;
    public Transform GroundCheck;
    public float CheckRadius;
    public LayerMask WhatIsGround;

    private int extraJump;
    public int extraJumpValeu;
  
    new public Rigidbody2D rigidbody;
    private SpriteRenderer sprite;
    private Animator animator;

    public Image Energy;
    private float HasteCoolDown =0.3f;

    public Transform TopCheck;
    private float TopCheckRadius;
    public LayerMask Roof;
    public Collider2D poseStand;
    public Collider2D poseSquat;
    private bool jumpLock = false;

    private float damagecd = 0f;

    private void Awake()
    {
        livesBar = FindObjectOfType<LivesBar>();
        extraJump = extraJumpValeu;
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
       
        bullet = Resources.Load<Bullet>("Bullet");
        realspeed = speed;
        Cursor.visible = false;
        TopCheckRadius = TopCheck.GetComponent<CircleCollider2D>().radius;
       

    }
    private void Update()
    {
        damagecd += Time.deltaTime;
        HasteCoolDown += Time.deltaTime;
        if (Energy.fillAmount < 1 && isGrounded == true && HasteCoolDown>0.3f)
        {
            Energy.fillAmount += 0.6f* Time.deltaTime;
        }

        JumpDamageCoolDOwn += Time.deltaTime;
        curr_time -= Time.deltaTime;
        //Анимация вектор х
        moveVector.x = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("moveX", Mathf.Abs(moveVector.x));

        if (isGrounded == true)
        {
            extraJump = extraJumpValeu;
        }
        //Выстрел
        if (Input.GetKeyDown(KeyCode.Space) && isLevel1 == true && curr_time <= 0f && Time.timeScale == 1f)
        {
            curr_time = 1f;
            Shoot();
        }
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && extraJump > 0 && JumpDamageCoolDOwn >=0.6f && !jumpLock && Time.timeScale == 1f)
        {
            Myfx.PlayOneShot(JumpSound);
            rigidbody.velocity = Vector2.up * jumpforce;
            extraJump--;
        }else if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && extraJump == 0 && isGrounded == true && JumpDamageCoolDOwn >= 0.6f && !jumpLock && Time.timeScale == 1f)
        {
            Myfx.PlayOneShot(JumpSound);
            rigidbody.velocity = Vector2.up * jumpforce;
        }
        if (isLevel3 == true && poseStand.enabled == true) Haste();
    }

    private void FixedUpdate()
    {
            isGrounded = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, WhatIsGround);
        if (isLevel2 == false) animator.SetBool("IsGrounded", isGrounded);
       else animator.SetBool("IsGroundOsel", isGrounded);
        //БЕГ!!!!!!!!!!!
        if (Input.GetButton("Horizontal") && isLevel2 != true) Run();
        //бег осла
        if (isLevel2 == true) RunOsel();

      if(faceRight == false && moveVector.x > 0)
        {
            Flip();
        }else if(faceRight == true && moveVector.x < 0 && isLevel2 == false)
        {
            Flip();
        }
    }

    private void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, realspeed * Time.deltaTime);
       // sprite.flipX = direction.x < 0.0f;
    }
    
    
    private void Jump()
    {
        rigidbody.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
    }
    void Haste()
    {
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded == true && Energy.fillAmount>=0.01)
        {   
            animator.speed = 2.0f;
            realspeed = fastspeed;
            if (Input.GetButton("Horizontal"))
            {
                Energy.fillAmount -= 1.2f * Time.deltaTime;
                if (Energy.fillAmount <= 0.01) HasteCoolDown = 0;
            }

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) { speedlock = true; }
        }
        else
        {
            animator.speed = 1.0f;
           if (!speedlock) { realspeed = speed; }
           else if (speedlock && isGrounded) { speedlock = false; }
           else { realspeed = fastspeed; }
        }
    }

    private void Shoot()
    {
        Myfx.PlayOneShot(DamageSound);
        Vector3 position = transform.position; position.y += 1.5f;
      Bullet NewBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;
        if (faceRight == true)
            NewBullet.naprav = 1;
        if (faceRight == false)
            NewBullet.naprav = -1;
    }
    public override void ReciveDamage()
    {
        if (damagecd >= 0.23f)
        {
            Myfx.PlayOneShot(HitsSound);
            Lives--;
            damagecd = 0f;
            if (Lives == 0)
            {
                SceneManager.LoadScene("deathScene");
                //  Destroy(gameObject);
            }
        }
       
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "BulletEnemy")
        {
            ReciveDamage();
        }
    }
    void Flip()
    {
        faceRight = !faceRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    void SquatCheck()
    {
        if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && isGrounded==true)
        {
            realspeed = speed;
            animator.SetBool("squat", true);
            poseStand.enabled = false;
            poseSquat.enabled = true;
            jumpLock = true;
        }
        else if (!Physics2D.OverlapCircle(TopCheck.position, TopCheckRadius, Roof))
        {
            animator.SetBool("squat", false);
            poseStand.enabled = true;
            poseSquat.enabled = false;
            jumpLock = false;
        }
    }
    void RunOsel()
    {
        Vector3 direction = transform.right * 1;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, realspeed * Time.deltaTime);
    }

}

