using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
	public string sceneName;
    // Update is called once per frame
    public void ClickButtonSceneChanger()
    {
		SceneManager.LoadScene(sceneName);
    }
}
