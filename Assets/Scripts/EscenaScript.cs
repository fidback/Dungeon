using System;
using UnityEngine;

/// <summary>
/// Basic Menu Script.
/// At this version, it just shows a button to exit the game
/// </summary>
public class EscenaScript : MonoBehaviour {


	void Start ()
	{
		// Reseteamos el cursor por si venimos de clicar en algo
		try
		{
			Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
			GestorTextoCursorScript.cursor.HideText();
		}
		catch (Exception e)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogException(e);
			}
		}
	}


	void OnGUI()
	{
		const int buttonWidth = 80;
		const int buttonHeight = 50;

		// Draw a button to exit the game
		if ( GUI.Button( new Rect(30, Screen.height - 80, buttonWidth, buttonHeight), "Exit") )
		{
			Application.Quit();
		}

	}

}
