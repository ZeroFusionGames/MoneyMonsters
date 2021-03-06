﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
	private float timeScaleOriginal = 1;
	private bool paused;
	[SerializeField]
	private GameObject playerHUD;
	[SerializeField]
	private GameObject pauseMenu;

	private void Awake()
	{
		Time.timeScale = 1;
	}

	void Update()
    {
		if (InputManager.instance.KeyDown("Pause") && paused == true || InputManager.instance.KeyDown("Cancel") && paused == true)
		{
			Time.timeScale = timeScaleOriginal;
			pauseMenu.SetActive(false);
			playerHUD.SetActive(true);
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			paused = false;
		}
		else if (InputManager.instance.KeyDown("Pause") && paused == false || InputManager.instance.KeyDown("Cancel") && paused == false)
		{
			timeScaleOriginal = 1;
			Time.timeScale = 0f;
			playerHUD.SetActive(false);
			pauseMenu.SetActive(true);
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			Resources.UnloadUnusedAssets();
			paused = true;
		}

	}
}
