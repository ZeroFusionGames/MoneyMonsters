using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PickUpable : Interactable
{
	[Header("Pick up settings")]
	public bool isTool = false;
}
