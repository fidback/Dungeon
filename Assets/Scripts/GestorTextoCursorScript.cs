using UnityEngine;
using System.Collections;


/*********************************************************
 * Script para gestionar el texto que se muestra bajo
 * el cursor
 * 
 * Es Singleton. Requiere un GUIText que muestre el texto
 * 
 * Tiene 2 metodos: ShowText(string message) y HideText()
 ********************************************************/
[RequireComponent (typeof(GUIText))]
public class GestorTextoCursorScript : MonoBehaviour {

	// Instancia unica de la clase
	public static GestorTextoCursorScript cursor;

	// Variable para almacenar la posicion del raton
	private Vector3 pos;


	// Al cargar el script comprobamos si ya existe una instancia
	void Awake () 
	{
		// Si no existe
		if (cursor == null)
		{
			// Marcamos el objeto para no ser destruido al cambiar de escena
			DontDestroyOnLoad(gameObject);
			// Asignamos esta instancia a la instancia unica Singleton
			cursor = this;
		}
		// Si ya existia
		else if (cursor != this)
		{
			// Destruimos este objeto
			Destroy(gameObject);
		}
	}


	// En cada frame del juego
	void Update()
	{
		// Actualizamos la posicion el texto
		pos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
		this.transform.position = pos; 
	}


	// Metodo que muestra el texto pasado como parametro
	public void ShowText (string messsage)
	{
		// Asignamos al GUIText que contiene este objeto, el texto del parametro
		guiText.text = messsage;
		// Mostramos el texto
		guiText.enabled = true;
	}


	// Metodo para ocultar el texto
	public void HideText ()
	{
		// Desactivamos el GUIText (asi lo ocultamos)
		guiText.enabled = false;
	}
}