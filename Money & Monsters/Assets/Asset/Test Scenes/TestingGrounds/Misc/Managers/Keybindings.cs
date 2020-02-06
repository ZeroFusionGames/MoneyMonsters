using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Keybindings", menuName = "Keybindings")]
public class Keybindings : ScriptableObject
{
	public KeyCode Jump, Interact, Pickup, Throw, Attack, Inventory, Pause, Cancel;

	public KeyCode CheckKey(string key)
	{
		switch(key)
		{
			case "Jump":
				return Jump;

			case "Interact":
				return Interact;

			case "Pickup":
				return Pickup;

			case "Throw":
				return Throw;

			case "Attack":
				return Attack;

			case "Inventory":
				return Inventory;

			case "Pause":
				return Pause;

			case "Cancel":
				return Cancel;

			default:
				return KeyCode.None;
		}
	}
}
