using UnityEngine;
using System.Collections;

public class ControlAjusteScript : MonoBehaviour {

	void OnGUI()
	{
		if (GUI.Button(new Rect(10, 100, 100, 30), "+ Salud"))
		{
			ControlJuegoScript.control.health += 10;
		}
		if (GUI.Button(new Rect(10, 140, 100, 30), "- Salud"))
		{
			ControlJuegoScript.control.health -= 10;
		}
		if (GUI.Button(new Rect(10, 180, 100, 30), "+ Experiencia"))
		{
			ControlJuegoScript.control.experience += 10;
		}
		if (GUI.Button(new Rect(10, 220, 100, 30), "- Experiencia"))
		{
			ControlJuegoScript.control.experience -= 10;
		}
		if (GUI.Button(new Rect(10, 260, 100, 30), "Guardar"))
		{
			ControlJuegoScript.control.Save();
		}
		if (GUI.Button(new Rect(10, 300, 100, 30), "Cargar"))
		{
			ControlJuegoScript.control.Load();
		}
	}
}
