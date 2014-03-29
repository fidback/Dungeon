using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ControlJuegoScript: MonoBehaviour {

	public static ControlJuegoScript control;

	public float health;
	public float experience;


	void Awake () {
		if (control == null)
		{
			DontDestroyOnLoad(gameObject);
			control = this;
		}
		else if (control != this)
		{
			Destroy(gameObject);
		}

	}
	
	// Update is called once per frame
	void OnGUI () {
		GUI.Label(new Rect(10, 10, 100, 30), "Salud: " + health);
		GUI.Label(new Rect(120, 10, 150, 30), "Experiencia: " + experience);
	}

	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

		PlayerData data = new PlayerData();
		data.health = health;
		data.experience = experience;

		bf.Serialize(file,data);
		file.Close();
	}

	public void Load()
	{
		if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize(file);
			file.Close();

			health = data.health;
			experience = data.experience;
		}
	}
}

[Serializable] // Para que la clase sea serializable (se pueda reducir a un flujo de datos binarios)
class PlayerData
{
	public float health;
	public float experience;
}