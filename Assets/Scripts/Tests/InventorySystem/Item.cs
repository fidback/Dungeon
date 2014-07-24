using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item
{
	public string itemName;
	public int itemID;
	public string itemDesc;
	public Texture2D itemIcon;
	public int itemPower;
	public int itemSpeed;
	public ItemType itemType;


	public enum ItemType
	{
		Weapon,
		Consumable,
		Quest
	}

	public Item (string name, int id, string description, int power, int speed, ItemType type)
	{
		itemName = name;
		itemID = id;
		itemDesc = description;
		itemIcon = Resources.Load<Texture2D>("Item Icons/" + name);
		itemPower = power;
		itemSpeed = speed;
		itemType = type;
	}

	public Item ()
	{
		itemID = -1;
	}
}
