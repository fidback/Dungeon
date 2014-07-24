using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour 
{
	public List<Item> items = new List<Item>();

	void Start()
	{
		items.Add(new Item("Bronze Sword", 0, "A bronze sword", 2, 0, Item.ItemType.Weapon));
		items.Add(new Item("Rotten Apple", 1, "A rotten apple", 0, 0, Item.ItemType.Consumable));
		items.Add(new Item("Power Potion", 2, "A potion that temporarily increases your power", 0, 0, Item.ItemType.Consumable));
	}
}
