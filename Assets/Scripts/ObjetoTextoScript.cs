using UnityEngine;
using System.Collections;


/************************************************
 * Script para los objetos interactivos que 
 * muestran un texto cuando se hace clic sobre
 * ellos
 ************************************************/
public class ObjetoTextoScript : MonoBehaviour {

	// Texto a mostrar
	public string textToShow;

	// Duracion del texto
	public float duration;
	
	
	// Cuando se hace clic dentro del Collider
	void OnMouseDown ()
	{
		// Mostramos el texto que se ha indicado si se ha rellenado
		if (textToShow.Length != 0)
		{
			if (duration > 0f)
			{
				// Llamamos a la corutina que muestra el texto durante los segundos indicados
				StartCoroutine(GestorTextoScript.text.Show(textToShow, duration));
			}
			else if (Debug.isDebugBuild)
			{
				Debug.Log("<color=blue>No has especificado la duracion! </color>" + duration);
			}
		}
		else
		{
			if (Debug.isDebugBuild)
			{
				Debug.Log("<color=blue>No has indicado el mensaje a mostrar! </color>" + textToShow);
			}
		}
	}
	
	
	// Establecemos un Gizmo personalizado para estos objetos interactivos
	void OnDrawGizmos() {
		Gizmos.DrawIcon(transform.position, "ManoGizmo.png");
	}
}
