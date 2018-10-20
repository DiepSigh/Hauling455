using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour {

    public AudioSource jump;
    public AudioSource coin;
    public AudioSource dead;

    private Animator anim;
	private Rigidbody2D rb;
	private float jumpForce = 150f;
	private bool canJump = true;
	//private int health = 3;

    gameManager gm;

    // Use this for initialization
    void Start () {
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
        gm = GameObject.Find("GameManager").GetComponent<gameManager>();
    }

	//private void TakeDamage(){
	//	health--;
	//	if(health <= 0)
	//	{
	//		GameOver();
	//	}
	//}

	private void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Ground"){
			anim.SetBool("isJumping", false);
			canJump = true;
		}

		//if(other.gameObject.tag == "Enemy"){
		//	TakeDamage();
		//}

	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            //Destroy coin and add coin to score in gameManager script
            Destroy(other.gameObject);
            gm.coinCollected();
            coin.Play();
        }

        if (other.gameObject.tag == "Sweeper")
        {
            //Stop time and gameover in gameManager script
            dead.Play();
            gm.GameOver();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canJump == true)
            {
                //Set isJumping to true for animation, canJump is false so player cannot jump again, player jumps.
                anim.SetBool("isJumping", true);
                canJump = false;
                rb.AddForce(new Vector2(0.0f, jumpForce));
                jump.Play();
            }
        }

        //Falling and jumping animation controller
        if (rb.velocity.y < 0)
        {
            anim.SetBool("isFalling", true);
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isFalling", false);
        }

    }
}
