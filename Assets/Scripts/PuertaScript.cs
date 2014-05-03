using System;
using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SpriteRenderer))]

/************************************************
 * Script para las puerta o salidas de una sala 
 * que nos llevan a otra sala al clicar sobre ellos
 ************************************************/
public class PuertaScript : MonoBehaviour {

	// Esta cerrada?
	public bool isLocked = false;

	// Necesita llave?
	public bool needKey = false;

	// Texto cuando esta cerrada
	public string lockedText = "Cerrada";

	// Texto al abrirla
	public string unlockedText = "Abierta";

	// Escena a cargar para la vista detalle
	public string sceneToLoad;


	// Cuando se hace clic dentro del Collider
	void OnMouseDown ()
	{
		// Si no esta cerrada
		if (!isLocked) {
			// Cargamos la escena especificada (si existe)
			if (sceneToLoad.Length != 0) {
					try {
							Application.LoadLevel (sceneToLoad);
					} catch (Exception e) {
							if (Debug.isDebugBuild) {
									Debug.LogException (e, this);
							}
					}
			} else {
				if (Debug.isDebugBuild) {
						Debug.Log ("<color=blue>No has indicado la escena a cargar!</color>");
				}
			}
		} else {
			// Si necesita llave
			if (needKey) {
				// Mostramos el texto de que esta cerrada
				StartCoroutine(GestorTextoScript.text.Show(lockedText));
			} else {
				// Si no necesita llave, la abrimos, quitamos el sprite y mostramos el texto
				isLocked = false;
				renderer.enabled=false;
				StartCoroutine(GestorTextoScript.text.Show(unlockedText));
			}
		}
	}


	// Establecemos un Gizmo personalizado para estos objetos interactivos
	void OnDrawGizmos() {
		Gizmos.DrawIcon(transform.position, "SalidaGizmo.png");
	}

}
