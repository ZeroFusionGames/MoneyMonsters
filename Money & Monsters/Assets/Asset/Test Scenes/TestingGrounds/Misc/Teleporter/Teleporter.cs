using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : Interactable
{
	public string Scenename;
	public Animator animator;
	public bool hasAnimator = true;
	[SerializeField]private HUDManager hudManager;


	private void Start()
	{
		base.Start();
		hudManager = GameObject.FindGameObjectWithTag("Main Manager").GetComponent<HUDManager>();
	}
	public override void Interact()
	{
		base.Interact();
		Debug.Log("switched");
		if (hasAnimator)
		{
			animator.Play("Activate");
		}
		else
		{
			SceneManager.LoadScene(Scenename);
			DontDestroyOnLoad(player);
		}
		
	}

	void Teleport()
	{
		SceneManager.LoadScene(Scenename);
	}

	void fadeout()
	{
		hudManager.fadeInPlayerHUD();
	}
}
