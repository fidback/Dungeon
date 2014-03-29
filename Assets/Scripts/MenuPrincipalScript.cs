using System;
using UnityEngine;
using System.Collections;

public class MenuPrincipalScript : MonoBehaviour {

	// Clase que contiene el nombre de la escena a cargar y el texto a mostrar en el boton
	[Serializable]
	public class SceneStrings
	{
		public string sceneName;
		public string textToShow;
	}

	// Nombre de la primera escena del juego
	public string gameScene;

	// Array para contener las escenas de pruebas a cargar
	public SceneStrings [] scenesToLoad;

	private GUIStyle centeredStyle;


	// Dibujamos un boton para comenzar la partida y otros para escenas de prueba de algunas caracteristicas
	void OnGUI()
	{


		const int buttonWidth = 250;
		const int buttonHeight = 30;
		const int buttonSpace = buttonHeight + 5;
		int hLocation = Screen.width / 2 - (buttonWidth / 2);
		int vLocation = (1 * Screen.height / 3);
		
		// Dibujamos un boton para comenzar la partida
		if ( GUI.Button( new Rect(hLocation, vLocation, buttonWidth, buttonHeight), "Iniciar el juego") )
		{

			try
			{
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


		centeredStyle = GUI.skin.GetStyle("Label");
		centeredStyle.alignment = TextAnchor.UpperCenter;

		vLocation += buttonSpace;
		GUI.Label(new Rect(hLocation, vLocation, buttonWidth, buttonHeight), "Escenas de pruebas", centeredStyle);

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
