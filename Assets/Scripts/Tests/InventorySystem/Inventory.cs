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
	private bool showTooltip;
	private string tooltip;


	void Start()
	{
		for (int i = 0; i < (slotsX * slotsY); i++)
		{
			slots.Add(new Item());
			inventory.Add (new Item());
		}
		database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
		print (inventory.Count);
		AddItem(0);
		AddItem(0);
		AddItem(1);

		RemoveItem(0);
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
		tooltip = "";
		GUI.skin = skin;
		if (showInventory)
		{
			DrawInventory();
		}

		if (showTooltip)
		{
			GUI.Box (new Rect(Event.current.mousePosition.x + 20f, Event.current.mousePosition.y, 200, 200), tooltip, skin.GetStyle("Tooltip"));
		}
	}

	void DrawInventory()
	{
		int i = 0;
		for (int y = 0; y < slotsY; y++)
		{
			for (int x = 0; x < slotsX; x++)
			{
				Rect slotRect = new Rect(x * 110 + 10, y * 110 + 10, 100, 100);
				GUI.Box(slotRect, i.ToString(), skin.GetStyle("Slot"));
				slots[i] = inventory[i];
				if (slots[i].itemName != null)
				{
					GUI.DrawTexture(slotRect, slots[i].itemIcon);

					if (slotRect.Contains(Event.current.mousePosition))
					{
						tooltip = CreateTooltip(slots[i]);
						showTooltip = true;
					}
				}

				if (tooltip == "")
				{
					showTooltip = false;
				}

				i++;
			}
		}
	}


	string CreateTooltip(Item item)
	{
		tooltip = "";
		tooltip += "<color=#4DA4BF>" + item.itemName + "</color>\n\n";
		tooltip += "<color=#f2f2f2>" + item.itemDesc + "</color>\n";
		return tooltip;
	}


	void RemoveItem(int id)
	{
		for (int i = 0; i < inventory.Count; i++)
		{
			if (inventory[i].itemID == id)
			{
				inventory[i] = new Item ();
				break;
			}
		}
	}


	void AddItem(int id)
	{
		for (int i = 0; i < inventory.Count; i++)
		{
			if (inventory[i].itemName == null)
			{
				for (int j = 0; j < database.items.Count; j++)
				{
					if (database.items[j].itemID == id)
					{
						inventory[i] = database.items[j];
					}
				}

				break;
			}
		}
	}


	bool InventoryContains(int id)
	{
		foreach (Item item in inventory)
		{
			if (item.itemID == id)
			{
				return true;
			}
		}
		return false;
	}





}
