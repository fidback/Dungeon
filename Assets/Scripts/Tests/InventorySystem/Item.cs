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
}
