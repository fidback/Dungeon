using System;
using UnityEngine;
using System.Collections;


/************************************************
 * Script para los objetos interactivos que 
 * se pueden clicar
 * 
 * Muestran un cursor animado y un texto bajo el cursor
 * al pasar el raton por encima 
 ************************************************/
public class InteractivoScript : MonoBehaviour {

	// Nombre del objeto a mostrar al pasar el raton
	public string nameToShow;

	// Array de texturas del cursor que queremos que se muestre al pasar el raton
	public Texture2D[] cursorTexture;

	// Velocidad en frames por segundo a la que queremos animar el cursor
	public float framesPerSecond;

	// Si muestra otro cursor al clicar
	public bool textureOnClick = false;

	// Cursor para cuando se clica
	public Texture2D clickTexture;

	// Punto de la textura que señala donde apuntamos
	public Vector2 hotSpot = Vector2.zero;

	// Modo de cursor Hardware/Software (dejar en auto)
	private CursorMode cursorMode = CursorMode.Auto;


	// Cuando el raton entra en el Collider
	void OnMouseEnter () 
	{
		try
		{
			// Cambiamos el cursor por el primero de nuestro array de texturas
			Cursor.SetCursor(cursorTexture[0], hotSpot, cursorMode);
			// Mostramos el nombre del objeto bajo el cursor
			GestorTextoCursorScript.cursor.ShowText(nameToShow);
		}
		catch (Exception e)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogException(e);
			}
		}

		if (Debug.isDebugBuild)
		{
			Debug.Log("<color=blue>Me tocas!</color>");
		}
	}
	

	// Cuando el raton sale del Collider
	void OnMouseExit () 
	{
		try
		{
			// Volvemos a dejar el cursor por defecto
			Cursor.SetCursor(null, hotSpot, cursorMode);
			// Ocultamos el texto del cursor
			GestorTextoCursorScript.cursor.HideText();
		}
		catch (Exception e)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogException(e);
			}
		}
		if (Debug.isDebugBuild)
		{
			Debug.Log("<color=blue>Ya no me tocas!</color>");
		}
	}


	// Mientras estamos encima del objeto
	void OnMouseOver () {
		if (!textureOnClick)
		{
			// Animamos el cursor usando el resto de (tiempo * fps / frames)
			int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
			index = index % cursorTexture.Length;
			Cursor.SetCursor( cursorTexture[ index ], hotSpot, cursorMode);
		}

	}


	// Establecemos un Gizmo personalizado para estos objetos interactivos
	void OnDrawGizmos() {
		if (cursorTexture.Length >= 1)
		{
			// El gizmo tiene el mismo nombre que la textura basica del cursor
			Gizmos.DrawIcon(transform.position, cursorTexture[0].name);
		}
	}

	// Cuando se hace clic dentro del Collider
	void OnMouseDown ()
	{
		if (clickTexture && textureOnClick)
		{
			// Cambiamos el cursor por el indicado en la variable
			Cursor.SetCursor( clickTexture, hotSpot, cursorMode);
		}
	}

	// Cuando se hace clic dentro del Collider
	void OnMouseUp ()
	{
		if (clickTexture && textureOnClick)
		{
			// Cambiamos el cursor por el indicado en la variable
			Cursor.SetCursor( cursorTexture[0], hotSpot, cursorMode);
		}
	}

}
