﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	public static InputManager instance;

	public Keybindings keybindings;

	void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
		else if(instance != this)
		{
			Destroy(this);
		}
		
	}

	public bool KeyDown(string key)
	{
		if(Input.GetKeyDown(keybindings.CheckKey(key)))
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool KeyUp(string key)
	{
		if (Input.GetKeyUp(keybindings.CheckKey(key)))
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool GetKey(string key)
	{
		if (Input.GetKey(keybindings.CheckKey(key)))
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}
