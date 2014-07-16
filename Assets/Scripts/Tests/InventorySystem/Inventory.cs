using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour 
{
	public int slotsX, slotsY;
	public GUISkin skin;
	public List<Item> inventory = new List<Item>();
	public List<Item> slots = new List<Item>();
	private bool showInventory = false;
	private ItemDatabase database;


	void Start()
	{
		for (int i = 0; i < (slotsX * slotsY); i++)
		{
			slots.Add(new Item());
		}
		database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
		print (inventory.Count);
		inventory.Add (database.items[0]);
		inventory.Add (database.items[1]);
	}

	void Update()
	{
		if (Input.GetButtonDown("Inventory"))
		{
			showInventory = !showInventory;
		}
	}

	void OnGUI()
	{
		GUI.skin = skin;
		if (showInventory)
		{
			DrawInventory();
		}
	}

	void DrawInventory()
	{
		for (int x = 0; x < slotsX; x++)
		{
			for (int y = 0; y < slotsY; y++)
			{
				GUI.Box(new Rect(x * 110 + 10, y * 110 + 10, 100, 100), y.ToString(), skin.GetStyle("Slot"));
			}
		}
	}
}
