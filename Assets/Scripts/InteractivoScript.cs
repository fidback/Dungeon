using System;
using UnityEngine;
using System.Collections;

public class InteractivoScript : MonoBehaviour {

	// Nombre del objeto a mostrar al pasar el raton
	public string nameToShow;

	// Textura del cursor que queremos que se muestre al pasar el raton
	public Texture2D[] cursorTexture;

	public float framesPerSecond;

	// Punto de la textura que señala donde apuntamos
	public Vector2 hotSpot = Vector2.zero;

	private CursorMode cursorMode = CursorMode.Auto;


	// Cuando el raton entra en el Collider
	void OnMouseEnter () 
	{
		try
		{
			Cursor.SetCursor(cursorTexture[0], hotSpot, cursorMode);
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

	void OnMouseOver () {
		int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
		index = index % cursorTexture.Length;
		//spriteRenderer.sprite = sprites[ index ];
		Cursor.SetCursor( cursorTexture[ index ], hotSpot, cursorMode);
	}


	// Establecemos un Gizmo personalizado para estos objetos interactivos
	void OnDrawGizmos() {
		if (cursorTexture.Length >= 1)
		{
			Gizmos.DrawIcon(transform.position, cursorTexture[0].name);
		}
	}

}
