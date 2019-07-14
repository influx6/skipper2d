using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private float input;
    Animator anim;
    Rigidbody2D rb;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
		this.updateDirection();

        if (input != 0)
        {
            anim.SetBool("isRunning", true);
            return;
        }
        anim.SetBool("isRunning", false);
    }

    private void updateDirection(){
		if (input > 0){
			transform.eulerAngles = new Vector3(0, 0, 0);
            return;
		}
		if (input < 0) {
            transform.eulerAngles = new Vector3(0, 180, 0);
		}
	}

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        // get current input.
        input = Input.GetAxisRaw("Horizontal");

        // Set player velocity
        rb.velocity = new Vector2(input * speed, rb.velocity.y);
    }

    public void TakeDamage(int damage){
        health -= damage;
        if (health <= 0){
            // destroy the player with health below 0
            Destroy(gameObject);
        }
    }
}
