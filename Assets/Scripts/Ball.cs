using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private bool started = false;
	private Vector3 paddleToBallVector;
	
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!started) {
		// Lock the ball relative to the paddle.
			this.transform.position = paddle.transform.position + paddleToBallVector;
		}
		
		// Wait for a mouse press to launch.
		if (Input.GetMouseButtonDown(0)){
			started = true;
			print ("Mouse clicked, launch ball.");
			this.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f, 10f);
			GetComponent<AudioSource>().Play ();
		}
	}
	
	void OnCollisionEnter2D (Collision2D collision){
		Vector2 tweak = new Vector2 (Random.Range (0f, 0.2f), Random.Range (0f, 0.2f));
	
		if (started) {
			GetComponent<AudioSource>().Play ();
			this.GetComponent<Rigidbody2D>().velocity += tweak;
		}
	}
}
