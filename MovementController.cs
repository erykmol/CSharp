using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementController : MonoBehaviour {

	public float moveSpeed;
	public float plusSpeed;
	public float jumpForce;

	public LayerMask groundSelected;

	
	private bool jumpAgain = true;
	private bool grounded;

	public Text countScore;
	float playerScore = 0;
	

	private Rigidbody2D bubbleRgBod;
	private Collider2D bubbleCollider;

	// Use this for initialization
	void Start () {
		bubbleRgBod = GetComponent<Rigidbody2D>();
		bubbleCollider = GetComponent<Collider2D>();
	}

	void OnTriggerEnter2D(Collider2D CollisionInstance)
	{
		
		if(CollisionInstance.gameObject.layer == 10)
		{
			moveSpeed+=plusSpeed;

		}
	}

	void OnCollisionEnter2D(Collision2D CollisionInstance)
	{
		if(CollisionInstance.gameObject.tag == "Enemy")
		{
			moveSpeed -= (float)CollisionInstance.gameObject.GetComponent<Rigidbody2D>().gravityScale/2;
		}
	}
	// Update is called once per frame
	void Update () {
		grounded = Physics2D.IsTouchingLayers(bubbleCollider,groundSelected);
		bubbleRgBod.velocity = new Vector2(moveSpeed,bubbleRgBod.velocity.y);
		if(bubbleRgBod.velocity.x>0)
		{
			playerScore += transform.position.x/1000.0f*moveSpeed;
			countScore.text = "Distance: " + playerScore.ToString("F1");
		}
		if(Input.GetMouseButtonDown(0))
		{
			if(grounded)
			{
				bubbleRgBod.velocity = new Vector2(bubbleRgBod.velocity.x, jumpForce);
				jumpAgain = true;
			}
			else
			{
				if(jumpAgain)
				{
				bubbleRgBod.velocity = new Vector2(bubbleRgBod.velocity.x, jumpForce);
				jumpAgain = false;
				}
			}
			
		}

	}
}

