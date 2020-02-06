using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
	private string thisScene;
	void Start()
	{
		thisScene = SceneManager.GetActiveScene().name;
	}

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.R))
		{
			SceneManager.LoadScene(thisScene);
		}
    }
}
