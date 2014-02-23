using UnityEngine;

/// <summary>
/// Basic Menu Script.
/// At this version, it just shows a button to exit the game
/// </summary>
public class MenuScript : MonoBehaviour {

	void OnGUI()
	{
		const int buttonWidth = 80;
		const int buttonHeight = 50;

		// Draw a button to exit the game
		if ( GUI.Button( new Rect(30, Screen.height - 80, buttonWidth, buttonHeight), "Exit") )
		{
			Application.Quit();
		}

	}

}
