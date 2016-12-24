using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	private Ball ball;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!autoPlay){
			MoveWithMouse();
			} else {
				AutoPlay();
			}
	}
	
	void AutoPlay() {
		Vector3 paddlePos = new Vector3 (ball.transform.position.x, this.transform.position.y,
																this.transform.position.z);
		this.transform.position = paddlePos;
	}
	
	void MoveWithMouse() {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, this.transform.position.z);
		float xpos = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp(xpos, 0.5f, 15.5f);
		this.transform.position = paddlePos;	
	}
}
