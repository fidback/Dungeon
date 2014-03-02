using System;
using UnityEngine;
using System.Collections;

public class EscenaDetalleScript : MonoBehaviour {

	// Escena padre
	public string parentScene;


	// Dibujamos un boton para volver a la escena anterior
	void OnGUI()
	{
		const int buttonWidth = 80;
		const int buttonHeight = 50;

		// Dibujamos un boton para volver a la escena anterior
		if ( GUI.Button( new Rect(30, 30, buttonWidth, buttonHeight), "Volver") )
		{
			if (parentScene.Length != 0)
			{
				try
				{
					Application.LoadLevel(parentScene);
				}
				catch (Exception e)
				{
					if (Debug.isDebugBuild)
					{
						Debug.LogException(e,this);
					}

				}
			}
			else
			{
				if (Debug.isDebugBuild)
				{
					Debug.Log("<color=blue>No has indicado la escena a cargar!</color>");
				}
			}
		}		
	}
}
