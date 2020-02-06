using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Object set",menuName =	"Object set")]
public class ObjectSet : ScriptableObject
{
	public GameObject[] objects;
}
