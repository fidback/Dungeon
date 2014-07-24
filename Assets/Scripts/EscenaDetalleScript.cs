using System;
using UnityEngine;
using System.Collections;

/****************************************************
 * Script para el control de las escena detalle.
 * Muestra un boton para volver a la escena anterior.
 ****************************************************/
public class EscenaDetalleScript : MonoBehaviour {

	// Escena padre a la que volver si se pulsa el boton
	public string parentScene;

	// Imagen para el boton de volver
	public Texture2D backImage;


	void OnGUI()
	{
		// Dimensiones del boton
		const int buttonWidth = 80;
		const int buttonHeight = 50;

		// Preparamos el contenido del boton (una imagen y un tooltip)
		GUIContent content = new GUIContent( backImage, "Volver");
		// Dibujamos el boton para volver a la escena anterior
		if ( GUI.Button( new Rect(10, Screen.height - 60, buttonWidth, buttonHeight), content) )
		{
			// Si la variable contiene algo
			if (parentScene.Length != 0)
			{
				// Intentamos cargar la escena
				try
				{
					Application.LoadLevel(parentScene);
				}
				// Es probable que el nombre de la escena estuviera mal escrito
				// O que la escena no este añadida a la build
				// En ese caso, fallara, pero cogemos la excepcion y la mostramos
				catch (Exception e)
				{
					if (Debug.isDebugBuild)
					{
						Debug.LogException(e,this);
					}

				}
			}
			// Si no hemos especificado la escena a cargar, mostramos un aviso
			else
			{
				if (Debug.isDebugBuild)
				{
					Debug.Log("<color=blue>No has indicado la escena a cargar!</color>");
				}
			}
		}

		// Definimos donde va el tooltip
		GUI.Label(new Rect (31, Screen.height - 85, 38, 30), GUI.tooltip);
	}
}
