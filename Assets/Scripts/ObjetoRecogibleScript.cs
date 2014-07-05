using UnityEngine;
using System.Collections;

public class ObjetoRecogibleScript : MonoBehaviour {

	void OnMouseDown()
	{
		GestorInventarioScript.inventory.AddKey();
		renderer.enabled=false;
		renderer.collider2D.enabled=false;
		Destroy(gameObject, 5);
	}
}
