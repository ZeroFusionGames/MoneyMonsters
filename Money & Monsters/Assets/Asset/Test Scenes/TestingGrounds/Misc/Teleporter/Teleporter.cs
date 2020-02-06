using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Teleporter : Interactable
{
	public string Scenename;


	public override void Interact()
	{
		base.Interact();
		Debug.Log("switched");
		
		SceneManager.LoadScene(Scenename);
		
	}
}
