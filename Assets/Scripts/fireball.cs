using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{   
    public float timeForExist;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("selfDestruction", timeForExist);
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            selfDestruction();
        }
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 2, ForceMode2D.Impulse);
            selfDestruction();
        }
    }

    void selfDestruction(){
        anim.SetTrigger("explosion");
        Destroy(gameObject, 0.2f);
    }
}
