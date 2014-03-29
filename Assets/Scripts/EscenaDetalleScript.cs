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


	void OnGUI()
	{
		// Dimensiones del boton
		const int buttonWidth = 80;
		const int buttonHeight = 50;

		// Dibujamos el boton para volver a la escena anterior
		if ( GUI.Button( new Rect(30, 30, buttonWidth, buttonHeight), "Volver") )
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
	}
}
