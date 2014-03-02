using UnityEngine;
using System.Collections;

public class CajaCursorScript : MonoBehaviour {
	
	//public Transform target;  // Object that this label should follow
	public Vector3 offset = Vector3.up;    // Units in world space to offset; 1 unit above object by default
	public bool useMainCamera = true;   // Use the camera tagged MainCamera
	public Camera cameraToUse ;   // Only use this if useMainCamera is false

	private Vector3 pos;

	Camera cam ;
	
	void Start () 
	{
		cam = Camera.main;
	}
	
	
	void Update()
	{
		pos = cam.ScreenToWorldPoint(Input.mousePosition + offset);
		pos.z = -2;
		this.transform.position = pos; 
	}
}