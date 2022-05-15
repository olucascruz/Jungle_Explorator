using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnGround : MonoBehaviour
{
    private Rigidbody2D rig;
    public float speed;

    public Transform headPoint;
    public Transform rightCol;
    public Transform leftCol;
    public bool colliding;
    
    public float distance;

    bool isRight = true;

    public Transform groundCheck;

    public LayerMask layer;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D ground = Physics2D.Raycast(groundCheck.position, Vector2.down, distance);
        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, layer);

        if(ground.collider == false || colliding)
        {
            if(isRight)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                isRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                isRight = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            float height = collision.contacts[0].point.y - headPoint.position.y;

            if(height > 0){
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                Destroy(gameObject, 0.5f);
            }
        }
    }
}
