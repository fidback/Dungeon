using UnityEngine;
using System.Collections;

public class ObjetoTextoScript : MonoBehaviour {

	// Texto a mostrar
	public string textToShow;

	// Duracion del texto
	public float duration;
	
	
	// Cuando se hace clic dentro del Collider
	void OnMouseDown ()
	{
		// Mostramos el texto que se ha indicado
		if (textToShow.Length != 0)
		{
			if (duration > 0f)
			{
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
