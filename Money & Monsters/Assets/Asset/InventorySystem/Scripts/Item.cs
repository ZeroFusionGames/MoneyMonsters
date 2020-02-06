using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "InventorySystem/Item/Item")]
public class Item : ScriptableObject
{
	public int id;
	public GameObject prefab;
	public string title;
	[TextArea]
	public string description;
	public Sprite icon;
	public enum ItemType {Food, Equipment, Wepon, Potion, Spell};
	public ItemType itemType;
}
