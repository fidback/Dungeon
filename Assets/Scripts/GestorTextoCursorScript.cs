using UnityEngine;
using System.Collections;

public class GestorTextoCursorScript : MonoBehaviour {


	public static GestorTextoCursorScript cursor;
	
	private Vector3 pos;


	void Awake () 
	{
		if (cursor == null)
		{
			DontDestroyOnLoad(gameObject);
			cursor = this;
		}
		else if (cursor != this)
		{
			Destroy(gameObject);
		}
	}

	
	void Update()
	{
		pos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
		this.transform.position = pos; 
	}


	public void ShowText (string messsage)
	{
		guiText.text = messsage;
		guiText.enabled = true;
	}


	public void HideText ()
	{
		guiText.enabled = false;
	}
}