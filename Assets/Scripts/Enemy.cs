using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage;
    public float speed;
    public float minSpeed;
    public float maxSpeed;
    public Animator anim;
    public Rigidbody2D rb;

    Player player;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        speed = Random.Range(minSpeed, maxSpeed);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {

        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D hitObject)
    {
        if (hitObject.tag == "Player")
        {
            player.TakeDamage(damage);
        }
    }

    private void FixedUpdate()
    {
        
    }
}
