using System;
using UnityEngine;
using System.Collections;


/************************************************
 * Script para los objetos interactivos que 
 * pasan a una escena de vista detalle cuando se
 * hace clic sobre ellos
 ************************************************/
public class ObjetoDetalleScript : MonoBehaviour {
	
	// Escena a cargar para la vista detalle
	public string sceneToLoad;


	// Cuando se hace clic dentro del Collider
	void OnMouseDown ()
	{
		// Cargamos la escena especificada (si existe)
		if (sceneToLoad.Length != 0)
		{
			try
			{
				Application.LoadLevel(sceneToLoad);
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
