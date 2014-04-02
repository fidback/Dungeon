using System;
using UnityEngine;
using System.Collections;


/************************************************
 * Script para el menu principal provisional
 * 
 * Muestran un boton apra iniciar la partida y
 * varios botones adicionales segun la lista de
 * escenas que se le proporcione en el inspector
 ************************************************/
public class MenuPrincipalScript : MonoBehaviour {

	// Clase para representar la estructura de datos de nuestro array de escenas a mostrar
	// contiene el nombre de la escena a cargar y el texto a mostrar en el boton
	[Serializable]
	public class SceneStrings
	{
		// Nombre fisico de la escena
		public string sceneName;
		// Texto a mostrar en el boton
		public string textToShow;
	}

	// Nombre de la primera escena del juego
	public string gameScene;

	// Array para contener las escenas de pruebas a cargar
	public SceneStrings [] scenesToLoad;

	// variable para almacenar el estilo centrado para el texto
	private GUIStyle centeredStyle;


	// Dibujamos un boton para comenzar la partida y otros para escenas de prueba de algunas caracteristicas
	void OnGUI()
	{
		// Dimensiones de los botones
		const int buttonWidth = 250;
		const int buttonHeight = 30;
		const int buttonSpace = buttonHeight + 5;
		int hLocation = Screen.width / 2 - (buttonWidth / 2);
		// Posicion vertical del boton
		int vLocation = (1 * Screen.height / 3);
		
		// Dibujamos un boton para comenzar la partida
		if ( GUI.Button( new Rect(hLocation, vLocation, buttonWidth, buttonHeight), "Iniciar el juego") )
		{

			try
			{
				// Que carga la escena principal del juego
				Application.LoadLevel(gameScene);
			}
			catch (Exception e)
			{
				if (Debug.isDebugBuild)
				{
					Debug.LogException(e,this);
				}
			}
		}

		// Modificamos el estilo para centrar la siguiente etiqueta
		centeredStyle = GUI.skin.GetStyle("Label");
		centeredStyle.alignment = TextAnchor.UpperCenter;

		// Avanzamos verticalmente
		vLocation += buttonSpace;

		// Mostramos la etiqueta que separa la escena principal de las de pruebas
		GUI.Label(new Rect(hLocation, vLocation, buttonWidth, buttonHeight), "Escenas de pruebas", centeredStyle);

		// Ajustamos un poco la posicion porque la etiqueta ocupa menos que los botones
		vLocation -= 10;

		// Para cada escena de pruebas
		foreach (SceneStrings scene in scenesToLoad)
		{
			// Avanzamos hacia abajo la posicion del boton
			vLocation += buttonSpace;

			// Y mostramos el boton que carga dichas escena
			if ( GUI.Button( new Rect(hLocation, vLocation, buttonWidth, buttonHeight), scene.textToShow) )
			{
				
				try
				{
					// Que carga la escena correspondiente si se pulsa
					Application.LoadLevel(scene.sceneName);
				}
				catch (Exception e)
				{
					if (Debug.isDebugBuild)
					{
						Debug.LogException(e,this);
					}
				}
			}
		}
	}
}
