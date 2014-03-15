using UnityEngine;
using System.Collections;

[RequireComponent (typeof(GUIText))]
public class GestorTextoScript : MonoBehaviour {

	public static GestorTextoScript text;
	

	// Use this for initialization
	void Awake () 
	{
		if (text == null)
		{
			DontDestroyOnLoad(gameObject);
			text = this;
		}
		else if (text != this)
		{
			Destroy(gameObject);
		}
	}
	
	// Funcion para mostrar el texto indicado en pantalla durante la duracion indicada
	public IEnumerator Show (string m, float t)
	{
		if (Debug.isDebugBuild)
		{
			Debug.Log("Texto!");
		}
		guiText.enabled = true;
		guiText.text = m;
		// Vamos a tratar de parar la corutina anterior si la hubiese
		StopCoroutine("WaitForDisable");
		yield return StartCoroutine("WaitForDisable", t);
	}

	public IEnumerator WaitForDisable (float t)
	{
		yield return new WaitForSeconds(t);
		guiText.enabled = false;
	}
}
