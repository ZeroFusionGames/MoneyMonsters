using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonItemSpawner : MonoBehaviour
{
	[SerializeField]
	private GameObject[] spawnables;
	[SerializeField]
	private Dropdown spawnSelector;
	private Transform player;
    // Start is called before the first frame update
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("PlayerItemHolder").transform;
	}

    public void Spawn()
	{
		if(spawnSelector.value > 0)
		{
			Instantiate(spawnables[spawnSelector.value - 1], player.position, Quaternion.identity);
		}

		
	}
}
