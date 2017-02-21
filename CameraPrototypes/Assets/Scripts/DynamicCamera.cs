using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCamera : MonoBehaviour {

	// Time delay for the camera to follow the player
	public float smoothTime = 0.15f;
	// The velocity of the player
	private Vector3 velocity = Vector3.zero;
	// The player
	public Transform player;
	// The camera
	public Camera cam;
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		// Check if player exists
		if(player)
		{
			Vector3 point = cam.WorldToViewportPoint(player.position);
			Vector3 delta = player.position - cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
			Vector3 newPoint = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, newPoint, ref velocity, smoothTime);
		}
	}
}
