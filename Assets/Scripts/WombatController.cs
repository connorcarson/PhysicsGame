using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WombatController : MonoBehaviour {
	
	public float moveSpeed = 4;
	private Vector3 forward, right;
	//public Rigidbody rb;

	// Use this for initialization
	void Start ()
	{
		forward = Camera.main.transform.forward;
		forward.y = 0;
		forward = Vector3.Normalize(forward);
		right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward; //establishes right as 90 degrees from forward
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.anyKey)
			Move();
	}

	void Move()
	{
		Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
		Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
		Vector3 forwardMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");
		
		Vector3 heading = Vector3.Normalize(rightMovement + forwardMovement);

		transform.forward = heading; //makes rotation happen
		transform.position += rightMovement; //makes right movement happen
		transform.position += forwardMovement; //makes forward movement happen
		
		
	}
}
