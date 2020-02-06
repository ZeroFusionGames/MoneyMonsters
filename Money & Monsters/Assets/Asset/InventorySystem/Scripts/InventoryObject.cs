using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InventoryObject : ScriptableObject
{
	[SerializeField] private int InventorySize;
	public List<Item> container = new List<Item>();
	public bool inventoryfull;

	public void AddItem(Item item)
	{
		container.Add(item);
	}
	public void RemoveItem(Item item)
	{
		container.Add(item);
	}

	private void CheckIfInventoryFull()
	{
		if (container.Count >= InventorySize)
		{
			inventoryfull = true;
		}
		else { inventoryfull = false; }
	}

}
