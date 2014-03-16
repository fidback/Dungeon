using System;
using UnityEngine;
using System.Collections;

public class InteractivoScript : MonoBehaviour {

	// Nombre del objeto a mostrar al pasar el raton
	public string name;

	// Textura del cursor que queremos que se muestre al pasar el raton
	public Texture2D cursorTexture;

	// Punto de la textura que señala donde apuntamos
	public Vector2 hotSpot = Vector2.zero;

	private CursorMode cursorMode = CursorMode.Auto;


	// Cuando el raton entra en el Collider
	void OnMouseEnter () 
	{
		try
		{
			Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
			GestorTextoCursorScript.cursor.ShowText(name);
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
			Cursor.SetCursor(null, Vector2.zero, cursorMode);
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

}
