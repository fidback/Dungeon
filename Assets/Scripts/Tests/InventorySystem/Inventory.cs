using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour 
{
	public int slotsX, slotsY;
	public GUISkin skin;
	public List<Item> inventory = new List<Item>();
	private bool showInventory = false;
	private ItemDatabase database;
	private bool showTooltip;
	private string tooltip;

	private bool draggingItem;
	private Item draggedItem;
	private int prevIndex;


	void Start()
	{
		for (int i = 0; i < (slotsX * slotsY); i++)
		{
			inventory.Add (new Item());
		}
		database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
		print (inventory.Count);
		AddItem(0);
		AddItem(0);
		AddItem(1);
		AddItem(2);
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
		if (GUI.Button (new Rect(10,10,80,50), "Guardar"))
		{
			SaveInventory();
		}
		if (GUI.Button (new Rect(100,10,80,50), "Cargar"))
		{
			LoadInventory();
		}
		if (GUI.Button (new Rect(190,10,80,50), "Inventario"))
		{
			showInventory = !showInventory;
		}

		tooltip = "";
		GUI.skin = skin;
		if (showInventory)
		{
			DrawInventory();
			if (showTooltip)
			{
				GUI.Box (new Rect(Event.current.mousePosition.x + 20f, Event.current.mousePosition.y, 150, 120), tooltip, skin.GetStyle("Tooltip"));
			}
		}
		if (draggingItem)
		{
			GUI.DrawTexture(new Rect(Event.current.mousePosition.x + 15f, Event.current.mousePosition.y, 50, 50), draggedItem.itemIcon);
		}


	}

	void DrawInventory()
	{
		Event e = Event.current;

		int i = 0;
		for (int y = 0; y < slotsY; y++)
		{
			for (int x = 0; x < slotsX; x++)
			{
				Rect slotRect = new Rect(x * 60 + 280, y * 60 + 10, 50, 50);
				GUI.Box(slotRect, i.ToString(), skin.GetStyle("Slot"));
				if (inventory[i].itemName != null)
				{
					GUI.DrawTexture(slotRect, inventory[i].itemIcon);

					if (slotRect.Contains(e.mousePosition))
					{
						if (e.button == 0 && e.type == EventType.mouseDrag && !draggingItem)
						{
							draggingItem = true;
							prevIndex = i;
							draggedItem = inventory[i];
							inventory[i] = new Item();
						}
						if (e.type == EventType.mouseUp && draggingItem)
						{
							inventory[prevIndex] = inventory[i];
							inventory[i] = draggedItem;
							draggingItem = false;
							draggedItem = null;
						}

						if (!draggingItem)
						{
							tooltip = CreateTooltip(inventory[i]);
							showTooltip = true;
						}

						if (e.isMouse && e.type == EventType.mouseDown && e.button == 1)
						{
							if (inventory[i].itemType == Item.ItemType.Consumable)
							{
								UseConsumable(inventory[i], i, true);
							}
						}
					}


				}
				else
				{
					if (slotRect.Contains(e.mousePosition))
					{
						if (e.type == EventType.mouseUp && draggingItem)
						{
							inventory[i] = draggedItem;
							draggingItem = false;
							draggedItem = null;
						}
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


	private void UseConsumable(Item item, int slot, bool deleteItem)
	{
		switch (item.itemID)
		{
		case 1:
			print (item.itemName + " restores health");
			break;
		case 2:
			print (item.itemName + " buffs something");
			break;
		default:
			print (item.itemName + " has no specified effect");
			break;
		}

		if (deleteItem)
		{
			inventory[slot] = new Item();
		}
	}

	void SaveInventory()
	{
		for (int i = 0; i < inventory.Count; i++)
		{
			PlayerPrefs.SetInt("Inventory " + i, inventory[i].itemID);
		}

	}

	void LoadInventory()
	{
		int value = -1;
		for (int i = 0; i < inventory.Count; i++)
		{
			value = PlayerPrefs.GetInt("Inventory " + i, -1);
			if (value >= 0)
			{
				inventory[i] = database.items[value];
			}
			else
			{
				inventory[i] = new Item();
			}
		}
	}
}
