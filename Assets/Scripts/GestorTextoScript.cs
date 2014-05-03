using UnityEngine;
using System.Collections;

/*********************************************************
 * Script para gestionar el texto que se muestra en la 
 * parte de abajo de la pantalla
 * 
 * Es Singleton. Requiere un GUIText que muestre el texto
 * 
 * Tiene 1 metodo: Show(string m, float t)
 ********************************************************/
[RequireComponent (typeof(GUIText))]
public class GestorTextoScript : MonoBehaviour {

	// Instancia unica de la clase
	public static GestorTextoScript text;
	

	// Al cargar el script comprobamos si ya existe una instancia
	void Awake () 
	{
		// Si no existe
		if (text == null)
		{
			// Marcamos el objeto para no ser destruido al cambiar de escena
			DontDestroyOnLoad(gameObject);
			// Asignamos esta instancia a la instancia unica Singleton
			text = this;
		}
		// Si ya existia
		else if (text != this)
		{
			// Destruimos este objeto
			Destroy(gameObject);
		}
	}
	
	// Funcion para mostrar el texto indicado en pantalla durante la duracion indicada
	public IEnumerator Show (string m, float t = 3)
	{
		// Lo mostramos tambien en consola
		if (Debug.isDebugBuild)
		{
			Debug.Log(m);
		}
		// Activamos el GUIText que contiene el texto
		guiText.enabled = true;
		// Asignamos al GUIText el texto del parametro
		guiText.text = m;
		// Paramos la corutina anterior si la hubiese, para quitar el texto anterior
		StopCoroutine("WaitForDisable");
		yield return StartCoroutine("WaitForDisable", t);
	}


	// Corrutina que espera los segundos que le pasemos como parametro para borrar el texto
	public IEnumerator WaitForDisable (float t)
	{
		// Esperamos los segundos indicados
		yield return new WaitForSeconds(t);
		// Desactivamos el GUIText
		guiText.enabled = false;
	}
}
