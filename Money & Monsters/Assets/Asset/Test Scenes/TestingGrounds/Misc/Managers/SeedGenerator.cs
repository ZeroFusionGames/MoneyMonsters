using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedGenerator : MonoBehaviour
{

	public string stringSeed = "seed string";
	public bool useStringSeed;
	public int seed;
	public bool randomizeSeed = true;

	public void Awake()
	{
		if (useStringSeed)
		{
			seed = stringSeed.GetHashCode();
		}

		if(randomizeSeed)
		{
			seed = Random.Range(0, 99999);
		}

		//Random.InitState(seed);
	}
}
