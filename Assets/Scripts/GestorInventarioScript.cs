using UnityEngine;
using System.Collections;

public class GestorInventarioScript : MonoBehaviour
{

	private int numberOfKeys = 0;

	public static GestorInventarioScript inventory;

	// Al cargar el script comprobamos si ya existe una instancia
	void Awake () 
	{
		// Si no existe
		if (inventory == null)
		{
			// Marcamos el objeto para no ser destruido al cambiar de escena
			DontDestroyOnLoad(gameObject);
			// Asignamos esta instancia a la instancia unica Singleton
			inventory = this;
		}
		// Si ya existia
		else if (inventory != this)
		{
			// Destruimos este objeto
			Destroy(gameObject);
		}
	}


	// Añade una llave al contador de llaves
	public void AddKey()
	{
		numberOfKeys += 1;
	}

	// Quita una llave del contador de llaves
	public void SubtractKey()
	{
		numberOfKeys -= 1;
	}

	// Quita una llave del contador de llaves
	public int GetNumberOfKeys()
	{
		return numberOfKeys;
	}
}
