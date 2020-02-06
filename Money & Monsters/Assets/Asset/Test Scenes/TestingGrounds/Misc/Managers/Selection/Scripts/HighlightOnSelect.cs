using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightOnSelect : MonoBehaviour
{
	[SerializeField]
	private float speed = 1.0f;
	public List<GameObject> meshesToHighlight;
	private List<GameObject> meshesWithEmissions = new List<GameObject>();
	private List<Vector4> existingEmissionColours = new List<Vector4>();
	private Interactable selecting;
	private bool emissionDisabled;
	[SerializeField]
	private bool hasEmissions;
	private Vector4 unSelectColour = new Vector4(0, 0, 1 / 255);
	private Vector4 selectColour = new Vector4(240, 248, 0 / 255);
	// Start is called before the first frame update
	void Start()
    {
		selecting = this.GetComponent<Interactable>();
		
		int listSize = meshesToHighlight.Count;
		if(listSize <= 0)
		{
			meshesToHighlight.Add(this.gameObject);
		
		}
		if (hasEmissions == true)
		{
			foreach (GameObject i in meshesToHighlight)
			{
				Vector4 objectEmissionValue = i.GetComponent<Renderer>().material.GetVector("_EmissiveColor");
				if(objectEmissionValue != new Vector4(0, 0, 0 / 255))
				{
					meshesWithEmissions.Add(i);
					existingEmissionColours.Add(objectEmissionValue);
				}
			}
		}
		else
		{
			foreach (GameObject i in meshesToHighlight)
			{
				i.GetComponent<Renderer>().material.SetVector("_EmissiveColor", unSelectColour);
			}
		}
		
	}

    // Update is called once per frame
    void Update()
    {
		
        if(selecting.selected == true && selecting.unSelectable == false)
		{
			foreach (GameObject i in meshesToHighlight)
			{
				float t = Mathf.Sin(Time.deltaTime * speed);
				i.GetComponent<Renderer>().material.SetVector("_EmissiveColor", Vector4.Lerp(selectColour, unSelectColour, t));
				emissionDisabled = false;
			}
			
		}
		else if(selecting.selected == false && emissionDisabled == false || selecting.unSelectable == true && emissionDisabled == false)
		{
			foreach (GameObject i in meshesToHighlight)
			{
				i.GetComponent<Renderer>().material.SetVector("_EmissiveColor", unSelectColour);
			}
			foreach (GameObject i in meshesWithEmissions)
			{
				i.GetComponent<Renderer>().material.SetVector("_EmissiveColor", existingEmissionColours[meshesWithEmissions.IndexOf(i)]);
			}
			emissionDisabled = true;
		}
	}

	void OnDestroy()
	{
		foreach (GameObject i in meshesToHighlight)
		{
			i.GetComponent<Renderer>().material.SetVector("_EmissiveColor", unSelectColour);
		}
		foreach (GameObject i in meshesWithEmissions)
		{
			i.GetComponent<Renderer>().material.SetVector("_EmissiveColor", existingEmissionColours[meshesWithEmissions.IndexOf(i)]);
		}
	}
}
