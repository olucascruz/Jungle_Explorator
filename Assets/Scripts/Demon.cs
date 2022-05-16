using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : Enemy
{   
    
    public float distanceDetection;
    public float distanceAvance;

    public Rigidbody2D ball;
    public Transform direction;
    public float timeBall;
    private Animator anim;
    public float fireSpeed;

    public float JumpForce;
    private Rigidbody2D rig;

    private Transform positionPlayer;

    public Transform rightCol;
    public Transform leftCol;
    public bool colliding;

    public LayerMask layer;


    private bool isRight;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        positionPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        rig = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {   
        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, layer);
        if(colliding)
        {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);

        }

        
        if(positionPlayer.gameObject != null)
        {
            if(positionPlayer.position.x > transform.position.x)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                isRight = true;
            }
            else
            {   
                transform.eulerAngles = new Vector3(0, 180, 0);

                isRight = false;
            }
            
            if(Vector2.Distance(transform.position, positionPlayer.position) < distanceDetection && Vector2.Distance(transform.position, positionPlayer.position) > distanceAvance)
            {
                if(timeBall <= 0)
                {    
                    Fire();
                    timeBall = 2f;        
                }
                else
                {
                    timeBall -= Time.deltaTime;
                }
            }
            else
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);  
            }
        }

        
    }

   

    void Fire()
    {
        Rigidbody2D rb = Instantiate(ball, direction.transform.position, direction.transform.rotation);
        if(isRight)
        {
        rb.transform.eulerAngles = new Vector3(0, 180, 0);

        }
        else
        {
        rb.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        rb.velocity = transform.right * fireSpeed;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            Destroy(gameObject);
        }
    }
}
