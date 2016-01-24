using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
	
	private Rigidbody rb;
	public float speed;
	
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3(moveHorizontal,0,moveVertical);
		
		rb.AddForce(movement*speed);

		// anne - jump the ball
		if (Input.GetKeyDown(KeyCode.Space)) {
			rb.AddForce(Vector3.up * 150);
		}
    }
}
